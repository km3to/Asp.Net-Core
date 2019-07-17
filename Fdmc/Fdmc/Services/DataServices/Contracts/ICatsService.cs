using Fdmc.Models.DataModels;
using Fdmc.Models.InputModels;
using Fdmc.Models.ViewModels;
using System.Collections.Generic;

namespace Fdmc.Services.DataServices.Contracts
{
    public interface ICatsService
    {
        HomeIndexViewModel GetAll();

        CatDetailsViewModel GetById(string id);

        void Create(CatCreateInputModel cat);

        void Delete(string id);
    }
}
