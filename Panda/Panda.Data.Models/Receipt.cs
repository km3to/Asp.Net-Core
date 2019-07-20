using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Panda.Data.Models
{
    public class Receipt
    {
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public string RecipientId { get; set; }

        public AppUser Recipient { get; set; }

        [Required]
        public string PackageId { get; set; }

        public Package Package { get; set; }
    }
}
