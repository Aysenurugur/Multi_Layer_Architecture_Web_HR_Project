using Core.AbstractRepositories;
using Core.Entities;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ExpenseRepository : CrudRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ProjectIdentityDbContext context) : base(context)
        {
        }

        private ProjectIdentityDbContext DbContext
        {
            get { return context as ProjectIdentityDbContext; }
        }
        
        public async Task SetStatusAsync(Expense expense, bool status)
        {
            expense.IsApproved = status;
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByCompanyAsync(Guid id)
        {
            return await DbContext.Expenses.Include(x => x.User).Where(x => x.User.Company.CompanyID == id).ToListAsync();
        }
    }
}
