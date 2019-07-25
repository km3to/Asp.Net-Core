using System;

namespace Panda.BindingModels.ViewModels
{
    public class PackageDetailsViewModel
    {
        public string Address { get; set; }

        public string Status { get; set; }

        public DateTime? EstDeliveryTime { get; set; }

        public double Weight { get; set; }

        public string RecipientName { get; set; }

        public string Description { get; set; }
    }
}
