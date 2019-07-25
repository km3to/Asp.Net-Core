using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.BindingModels.ViewModels
{
    public class ReceiptDetailsViewModel
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string DeliveryAddress { get; set; }

        public double PackageWeight { get; set; }

        public string PackageDescription { get; set; }

        public string RecipientName { get; set; }
    }
}
