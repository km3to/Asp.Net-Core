using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Panda.BindingModels.InputModels
{
    public class PackageCreateInputModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 300)]
        public double Weight { get; set; }

        [Display]
        [Required]
        public string ShippingAddress { get; set; }

        public ICollection<IdAndNameBindingModel> Recipients { get; set; } = new List<IdAndNameBindingModel>();

        [Required]
        public string RecipientId { get; set; }
    }
}
