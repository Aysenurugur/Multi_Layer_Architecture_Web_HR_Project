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

        public async Task<int> CountCompaniesAsync(int companyID)
        {
            return await DbContext.Companies.CountAsync();
        }

        public async Task<IEnumerable<DayOff>> GetDayOffsAsync(int dayOffTypeID)
        {
            return await DbContext.DayOffs.Where(x => x.DayOffTypeID == dayOffTypeID).ToListAsync();
        }

        public Task<IEnumerable<User>> GetEmployeeListAsync(int companyID, out int employeeCount)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Expense>> GetExpensesAsync(int expenseID)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetManagerListAsync(int companyID, out int managerCount)
        {
            throw new NotImplementedException();
        }
    }
}
