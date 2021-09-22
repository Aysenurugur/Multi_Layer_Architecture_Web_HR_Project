using Core.AbstractRepositories;
using Core.Entities;
using Data.Context;
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

        public IEnumerable<Expense> GetAllByUserIDAsync(string userId)
        {
            return DbContext.Expenses.Where(x => x.UserID == userId).ToList();
        }

        //public async Task SendVetoMessageAsync(VetoMessage vetoMessage, string userID)
        //{
        //    vetoMessage.VetodBy = userID;
        //    await context.VetoMessages.AddAsync(vetoMessage);
        //}

        public async Task SetStatusAsync(Expense expense, bool status)
        {
            expense.IsApproved = status;
            await DbContext.SaveChangesAsync();
        }
    }
}
