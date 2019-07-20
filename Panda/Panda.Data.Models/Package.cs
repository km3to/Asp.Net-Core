using Panda.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Panda.Data.Models
{
    public class Package
    {
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public double Weight { get; set; }

        [Required]
        public string ShippingAddress { get; set; }

        public PackageStatus Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; } = DateTime.UtcNow;

        [Required]
        public string RecipientId { get; set; }

        public AppUser Recipient { get; set; }

        [Required]
        public string ReceiptId { get; set; }

        public Receipt Receipt { get; set; }
    }
}
