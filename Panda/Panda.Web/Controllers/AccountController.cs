using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Panda.BindingModels.ViewModels;
using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<PandaUser> userManager;
        private readonly SignInManager<PandaUser> signInManager;

        public AccountController(UserManager<PandaUser> userManager, SignInManager<PandaUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await this.signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: true);

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = new PandaUser { UserName = model.Username, Email = model.Email };
            var result = await this.userManager.CreateAsync(user, model.Password);
            await this.signInManager.SignInAsync(user, isPersistent: false);

            return this.Redirect("/");
        }

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return this.Redirect("/");
        }
    }
}
