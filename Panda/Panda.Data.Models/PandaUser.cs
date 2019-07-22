using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Panda.Data.Models
{
    public class PandaUser : IdentityUser
    {
        public PandaUser()
        {
            this.Roles = new HashSet<PandaUserRole>();
            this.Packages = new HashSet<Package>();
            this.Receipts = new HashSet<Receipt>();
        }

        public virtual ICollection<PandaUserRole> Roles { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
