using Eventures.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Data
{
    public class EventuresDbContext : IdentityDbContext<EventuresUser, EventuresUserRole, string>
    {
        public EventuresDbContext(DbContextOptions<EventuresDbContext> options)
            : base(options)
        {
        }
    }
}
