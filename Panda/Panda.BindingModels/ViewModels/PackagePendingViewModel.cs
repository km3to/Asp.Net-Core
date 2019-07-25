using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.BindingModels.ViewModels
{
    public class PackagePendingViewModel
    {
        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string RecipientName { get; set; }

        public string Id { get; set; }
    }
}
