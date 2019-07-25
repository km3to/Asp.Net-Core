using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Data.Models
{
    public class Package
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public PackageStatus PackageStatus { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        public string RecipientId { get; set; }

        public virtual PandaUser Recipient { get; set; }

        public string ReceiptId { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
