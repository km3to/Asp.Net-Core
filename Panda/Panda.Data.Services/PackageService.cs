using Panda.BindingModels;
using Panda.BindingModels.InputModels;
using Panda.BindingModels.ViewModels;
using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Data.Services
{
    public class PackageService : BaseService
    {
        public PackageService(PandaDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(PackageCreateInputModel model)
        {
            var package = new Package
            {
                Description = model.Description,
                PackageStatus = PackageStatus.Pending,
                RecipientId = model.RecipientId,
                ShippingAddress = model.ShippingAddress,
                Weight = model.Weight,
                EstimatedDeliveryDate = DateTime.UtcNow.AddDays(new Random().Next(0, 11))
            };

            await this.DbContext.Packages.AddAsync(package);
            await this.DbContext.SaveChangesAsync();
        }

        public ICollection<PackagePendingViewModel> GetPending()
        {
            var result = 
                this.DbContext
                .Packages
                .Where(x => x.PackageStatus == PackageStatus.Pending)
                .Select(x => new PackagePendingViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    RecipientName = x.Recipient.UserName,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight
                })
                .OrderBy(x => x.Weight)
                .ToList();

            return result;
        }

        public ICollection<PackagePendingViewModel> GetShipped()
        {
            var result =
                this.DbContext
                .Packages
                .Where(x => x.PackageStatus == PackageStatus.Shipped)
                .Select(x => new PackagePendingViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    RecipientName = x.Recipient.UserName,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight
                })
                .OrderBy(x => x.Weight)
                .ToList();

            return result;
        }

        public ICollection<PackagePendingViewModel> GetDelivered()
        {
            var result =
                this.DbContext
                .Packages
                .Where(x => x.PackageStatus == PackageStatus.Delivered)
                .Select(x => new PackagePendingViewModel
                {
                    Description = x.Description,
                    Id = x.Id,
                    RecipientName = x.Recipient.UserName,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight
                })
                .OrderBy(x => x.Weight)
                .ToList();

            return result;
        }

        public HomeIndexViewModel GetHomeIndexModel()
        {
            var result = new HomeIndexViewModel
            {
                Penging = 
                    this.DbContext
                    .Packages
                    .Where(x => x.PackageStatus == PackageStatus.Pending)
                    .Select(x => new IdAndNameBindingModel
                    {
                        Id = x.Id,
                        Name = x.Description
                    })
                    .ToList(),
            Shipped = this.DbContext
                    .Packages
                    .Where(x => x.PackageStatus == PackageStatus.Shipped)
                    .Select(x => new IdAndNameBindingModel
                    {
                        Id = x.Id,
                        Name = x.Description
                    })
                    .ToList(),
                Delivered = this.DbContext
                    .Packages
                    .Where(x => x.PackageStatus == PackageStatus.Delivered)
                    .Select(x => new IdAndNameBindingModel
                    {
                        Id = x.Id,
                        Name = x.Description
                    })
                    .ToList(),
            };

            return result;
        }

        public PackageDetailsViewModel Details(string id)
        {
            var result = 
                this.DbContext
                .Packages
                .Where(x => x.Id == id)
                .Select(x => new PackageDetailsViewModel
                {
                    Address = x.ShippingAddress,
                    Description = x.Description,
                    EstDeliveryTime = x.EstimatedDeliveryDate,
                    RecipientName = x.Recipient.UserName,
                    Status = x.PackageStatus.ToString(),
                    Weight = x.Weight
                })
                .FirstOrDefault();

            if (result == null)
            {
                throw new Exception($"No Package with id={id} in database!");
            }

            return result;
        }

        public async Task Ship(string id)
        {
            var package = this.DbContext.Packages.FirstOrDefault(x => x.Id == id);

            if (package == null)
            {
                throw new Exception($"No Package with id={id} in database!");
            }

            package.PackageStatus = PackageStatus.Shipped;

            await this.DbContext.SaveChangesAsync();
        }

        public async Task Deliver(string id)
        {
            var package = this.DbContext.Packages.FirstOrDefault(x => x.Id == id);

            if (package == null)
            {
                throw new Exception($"No Package with id={id} in database!");
            }

            package.PackageStatus = PackageStatus.Delivered;

            await this.DbContext.SaveChangesAsync();
        }

        public async Task Aquire(string id)
        {
            var package = this.DbContext.Packages.FirstOrDefault(x => x.Id == id);

            if (package == null)
            {
                throw new Exception($"No Package with id={id} in database!");
            }

            package.PackageStatus = PackageStatus.Aquired;

            await this.DbContext.SaveChangesAsync();
        }
    }
}
