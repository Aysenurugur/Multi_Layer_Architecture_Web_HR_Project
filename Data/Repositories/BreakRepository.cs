using Core.AbstractRepositories;
using Core.Entities;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class BreakRepository : CrudRepository<Break>, IBreakRepository
    {
        public BreakRepository(ProjectIdentityDbContext context) : base(context)
        {
        }

        private ProjectIdentityDbContext DbContext
        {
            get { return context as ProjectIdentityDbContext; }
        }

        public IEnumerable<Break> GetAllByUserIDAsync(string userId)
        {
            return DbContext.Breaks.Where(x => x.UserID == userId).ToList();
        }
    }
}
