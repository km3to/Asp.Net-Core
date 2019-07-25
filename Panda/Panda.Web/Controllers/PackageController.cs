using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Panda.BindingModels.InputModels;
using Panda.Data.Services;
using System;
using System.Threading.Tasks;

namespace Panda.Web.Controllers
{
    public class PackageController : Controller
    {
        private readonly AccountService accountService;
        private readonly PackageService packageService;
        private readonly ReceiptService receiptService;

        public PackageController(AccountService accountService, PackageService packageService, ReceiptService receiptService)
        {
            this.accountService = accountService;
            this.packageService = packageService;
            this.receiptService = receiptService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = new PackageCreateInputModel();
            model.Recipients = this.accountService.AllUsers();

            return this.View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(PackageCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.packageService.CreateAsync(model);

            return Redirect("/");
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult Details(string id)
        {
            var model = this.packageService.Details(id);

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Pending()
        {
            var model = this.packageService.GetPending();

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Ship(string id)
        {
            await this.packageService.Ship(id);

            return this.RedirectToAction("Pending");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Shipped()
        {
            var model = this.packageService.GetShipped();

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Deliver(string id)
        {
            await this.packageService.Deliver(id);

            return this.RedirectToAction("Shipped");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delivered()
        {
            var model = this.packageService.GetDelivered();

            return this.View(model);
        }

        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Aquire(string id)
        {
            await this.packageService.Aquire(id);

            await this.receiptService.Create(id, this.User.Identity.Name);

            return this.Redirect("/");
        }
    }
}
