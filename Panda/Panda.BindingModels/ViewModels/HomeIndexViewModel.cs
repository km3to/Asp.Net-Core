using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.BindingModels.ViewModels
{
    public class HomeIndexViewModel
    {
        public ICollection<IdAndNameBindingModel> Penging { get; set; } = new List<IdAndNameBindingModel>();

        public ICollection<IdAndNameBindingModel> Shipped { get; set; } = new List<IdAndNameBindingModel>();

        public ICollection<IdAndNameBindingModel> Delivered { get; set; } = new List<IdAndNameBindingModel>();
    }
}
