using Microsoft.AspNetCore.Mvc;
using Panda.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly PackageService packageService;

        public HomeController(PackageService packageService)
        {
            this.packageService = packageService;
        }

        public IActionResult Index()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.View("AIndex");
            }

            var model = this.packageService.GetHomeIndexModel();

            return this.View(model);
        }
    }
}
