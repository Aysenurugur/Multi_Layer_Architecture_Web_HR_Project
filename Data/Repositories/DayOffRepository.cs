using Core.AbstractRepositories;
using Core.Entities;
using Core.Entities.Identity;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class DayOffRepository : CrudRepository<DayOff> , IDayOffRepository
    {
        public DayOffRepository(ProjectIdentityDbContext context) : base(context)
        {
        }

        private ProjectIdentityDbContext DbContext
        {
            get { return context as ProjectIdentityDbContext; }
        }

      
    }
}
