using Microsoft.AspNetCore.Identity;
using Panda.BindingModels;
using Panda.BindingModels.InputModels;
using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Data.Services
{
    public class AccountService : BaseService
    {
        private readonly UserManager<PandaUser> userManager;
        private readonly SignInManager<PandaUser> signInManager;
        private readonly RoleManager<PandaUserRole> roleManager;

        public AccountService(
            UserManager<PandaUser> userManager,
            SignInManager<PandaUser> signInManager,
            RoleManager<PandaUserRole> roleManager,
            PandaDbContext dbContext) : base(dbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        public async Task<SignInResult> Login(AccountLoginInputModel model)
        {
            var result = await this.signInManager.PasswordSignInAsync(model.Username, model.Password, false, lockoutOnFailure: true);

            return result;
        }

        public async Task<SignInResult> Register(AccountRegisterInputModel model)
        {
            var user = new PandaUser { UserName = model.Username, Email = model.Email };

            var registerResult = await this.userManager.CreateAsync(user, model.Password);

            if (!registerResult.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, registerResult.Errors));
            }

            var adminRoleExists = await this.roleManager.RoleExistsAsync("Admin");

            if (!adminRoleExists)
            {
                await this.roleManager.CreateAsync(new PandaUserRole { Name = "Admin" });
            }

            var userRoleExists = await this.roleManager.RoleExistsAsync("User");

            if (!userRoleExists)
            {
                await this.roleManager.CreateAsync(new PandaUserRole { Name = "User" });
            }

            var usersCount = this.userManager.Users.Count();

            if (usersCount == 1)
            {
                await this.userManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                await this.userManager.AddToRoleAsync(user, "User");
            }

            var loginModel = new AccountLoginInputModel
            {
                Username = model.Username,
                Password = model.Password,
                RememberMe = false
            };

            var result = await this.Login(loginModel);

            return result;
        }

        public async Task Logout()
        {
            await this.signInManager.SignOutAsync();
        }

        public ICollection<IdAndNameBindingModel> AllUsers()
        {
            var result = 
                this.DbContext
                .Users
                .Select(x => new IdAndNameBindingModel
                {
                    Id = x.Id,
                    Name = x.UserName
                })
                .ToList();

            return result;
        }
    }
}
