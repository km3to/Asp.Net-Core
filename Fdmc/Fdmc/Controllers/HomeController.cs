using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fdmc.Models;
using Fdmc.Services.DataServices.Contracts;

namespace Fdmc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICatsService catService;

        public HomeController(ICatsService catService)
        {
            this.catService = catService;
        }

        public IActionResult Index()
        {
            var model = this.catService.GetAll();

            return this.View(model);
        }
    }
}
