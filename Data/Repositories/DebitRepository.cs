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
    class DebitRepository : CrudRepository<Debit>, IDebitRepository
    {
        public DebitRepository(ProjectIdentityDbContext context) : base(context)
        {
        }

        private ProjectIdentityDbContext DbContext
        {
            get { return context as ProjectIdentityDbContext; }
        }
    }
}
