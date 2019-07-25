using Panda.BindingModels.ViewModels;
using Panda.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Data.Services
{
    public class ReceiptService : BaseService
    {
        public ReceiptService(PandaDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<ReceiptIndexViewModel> GetMine(string currentUserName)
        {
            var result =
                this.DbContext
                .Receipts
                .Select(x => new ReceiptIndexViewModel
                {
                    Id = x.Id,
                    Fee = x.Fee,
                    IssuedOn = x.IssuedOn,
                    RecipientName = x.Recipient.UserName
                })
                .Where(x => x.RecipientName == currentUserName)
                .ToList();

            return result;
        }

        public async Task Create(string packageId, string username)
        {
            var userId = this.DbContext.Users.FirstOrDefault(x => x.UserName == username).Id;

            var receipt = new Receipt
            {
                Fee = 20m,
                IssuedOn = DateTime.UtcNow,
                PackageId = packageId,
                RecipientId = userId
            };

            await this.DbContext.Receipts.AddAsync(receipt);
            await this.DbContext.SaveChangesAsync();

            var package = this.DbContext.Packages.FirstOrDefault(x => x.Id == packageId);
            package.ReceiptId = receipt.Id;

            await this.DbContext.SaveChangesAsync();
        }

        public ReceiptDetailsViewModel Details(string id)
        {
            var result =
                this.DbContext
                .Receipts
                .Where(x => x.Id == id)
                .Select(x => new ReceiptDetailsViewModel
                {
                    DeliveryAddress = x.Package.ShippingAddress,
                    Id = x.Id,
                    IssuedOn = x.IssuedOn,
                    PackageDescription = x.Package.Description,
                    PackageWeight = x.Package.Weight,
                    RecipientName = x.Recipient.UserName
                })
                .FirstOrDefault();

            if (result == null)
            {
                throw new Exception($"No Receipt with id={id} in database!");
            }

            return result;
        }
    }
}
