using Core.AbstractRepositories;
using Core.Entities;
using Core.Entities.Identity;
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
    public class UserRepository : IUserRepository
    {
        public UserRepository(ProjectIdentityDbContext context) 
        {
            this.DbContext = context;
        }

        private ProjectIdentityDbContext DbContext { get; set; }

        public User Find(Expression<Func<User, bool>> predicate)
        {
            return DbContext.Set<User>().Where(predicate).FirstOrDefault();
        }

        public async Task<List<VetoMessage>> GetUserVetoMessages(Guid userId)
        {
            var debitMessages = DbContext.VetoMessages.Include(x => x.Debit).Where(x => x.Debit.User.Id == userId).ToList();
            var dayOffMessages = DbContext.VetoMessages.Include(x => x.DayOff).Where(x => x.DayOff.User.Id == userId).ToList();
            var expenseMessages = DbContext.VetoMessages.Include(x => x.Expense).Where(x => x.Expense.User.Id == userId).ToList();
            List<VetoMessage> vetoMessages = debitMessages.Concat(dayOffMessages).Concat(expenseMessages).ToList();

            return await Task.FromResult(vetoMessages);
        }

        public IEnumerable<User> List(Expression<Func<User, bool>> predicate)
        {
            return DbContext.Set<User>().Where(predicate);
        }

        public async Task SendVetoMessageAsync(VetoMessage vetoMessage)
        {
            await DbContext.VetoMessages.AddAsync(vetoMessage);
        }
    }
}
