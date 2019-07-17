using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fdmc.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public ICollection<IdAndNameViewModel> Cats { get; set; }
    }
}
