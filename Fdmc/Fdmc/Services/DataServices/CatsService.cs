using Fdmc.Data;
using Fdmc.Models.DataModels;
using Fdmc.Models.InputModels;
using Fdmc.Models.ViewModels;
using Fdmc.Services.DataServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fdmc.Services.DataServices
{
    public class CatsService : ICatsService
    {
        private readonly AppDbContext dbContext;

        public CatsService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(CatCreateInputModel cat)
        {
            var dbCat = new Cat
            {
                Name = cat.Name,
                Age = cat.Age,
                Breed = cat.Breed,
                ImageUrl = cat.ImageUrl
            };

            this.dbContext.Cats.Add(dbCat);
            this.dbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var dbCat = this.dbContext.Cats.FirstOrDefault(x => x.Id == id);

            this.dbContext.Cats.Remove(dbCat);
            this.dbContext.SaveChanges();
        }

        public HomeIndexViewModel GetAll()
        {
            var cats = this.dbContext
                .Cats
                .Select(x => new IdAndNameViewModel { Id = x.Id, Name = x.Name })
                .ToList();

            var result = new HomeIndexViewModel { Cats = cats };

            return result;
        }

        public CatDetailsViewModel GetById(string id)
        {
            var cat = this.dbContext.Cats.FirstOrDefault(x => x.Id == id);

            if (cat != null)
            {
                throw new Exception("No cat with such ID in DB");
            }

            var result = new CatDetailsViewModel();

            result.Age = cat.Age;
            result.Breed = cat.Breed;
            result.ImageUrl = cat.ImageUrl;
            result.Name = cat.Name;

            return result;
        }
    }
}
