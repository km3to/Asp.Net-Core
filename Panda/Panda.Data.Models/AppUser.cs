using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Panda.Data.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            this.Receipts = new HashSet<Receipt>();
            this.Packages = new HashSet<Package>();
        }

        public ICollection<Package> Packages { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
