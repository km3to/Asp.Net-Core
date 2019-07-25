using Microsoft.AspNetCore.Mvc;
using Panda.BindingModels.InputModels;
using Panda.Data.Services;
using System;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Panda.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await this.accountService.Login(model);

            if (!result.Succeeded)
            {
                return this.View(model);
            }

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            SignInResult result;
            try
            {
                result = await this.accountService.Register(model);
            }
            catch (Exception e)
            {
                return this.Json(e.Message);
            }

            if (!result.Succeeded)
            {
                return this.View(model);
            }

            return this.Redirect("/");
        }

        public async Task<IActionResult> Logout()
        {
            await this.accountService.Logout();

            return this.Redirect("/");
        }
    }
}
