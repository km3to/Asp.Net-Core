using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Panda.Data.Models
{
    public class Receipt
    {
        public string Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;

        public string RecipientId { get; set; }

        public PandaUser Recipient { get; set; }

        public string PackageId { get; set; }

        public Package Package { get; set; }
    }
}
