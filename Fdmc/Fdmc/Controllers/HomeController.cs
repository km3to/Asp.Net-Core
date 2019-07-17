using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fdmc.Models;
using Fdmc.Services.DataServices.Contracts;
using Fdmc.Models.InputModels;

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

        [Route("/cats/{id?}")]
        public IActionResult Details(string id)
        {
            var model = this.catService.GetById(id);

            return this.View(model);
        }

        [Route("/cats/add")]
        public IActionResult Add()
        {
            return this.View();
        }
                
        [Route("/cats/add")]
        [HttpPost]
        public IActionResult Add(CatCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.catService.Create(model);

            return this.RedirectToAction("Index");
        }
    }
}
