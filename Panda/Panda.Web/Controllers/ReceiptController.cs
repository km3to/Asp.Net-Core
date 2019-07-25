using Microsoft.AspNetCore.Mvc;
using Panda.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Web.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly AccountService accountService;
        private readonly ReceiptService receiptService;

        public ReceiptController(AccountService accountService, ReceiptService receiptService)
        {
            this.accountService = accountService;
            this.receiptService = receiptService;
        }

        public IActionResult Index()
        {
            var model = this.receiptService.GetMine(this.User.Identity.Name);

            return this.View(model);
        }

        public IActionResult Details(string id)
        {
            var model = this.receiptService.Details(id);

            return this.View(model);
        }
    }
}
