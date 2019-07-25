using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Data.Services
{
    public class BaseService
    {
        public BaseService(PandaDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        protected PandaDbContext DbContext { get; }
    }
}
