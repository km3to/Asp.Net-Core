using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.BindingModels.ViewModels
{
    public class ReceiptIndexViewModel
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecipientName { get; set; }
    }
}
