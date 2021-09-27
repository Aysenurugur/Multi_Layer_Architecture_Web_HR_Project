using Core.AbstractRepositories;
using Core.Entities;
using Core.Entities.Identity;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    //active passive status olaylarını sil, onlar zaten update!!!!
    class CompanyRepository : CrudRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ProjectIdentityDbContext context) : base(context)
        {
        }

        private ProjectIdentityDbContext DbContext
        {
            get { return context as ProjectIdentityDbContext; }
        }
    }
}
