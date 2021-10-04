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

        public async Task<IEnumerable<VetoMessage>> GetUserVetoMessages(Guid userId)
        {
            List<VetoMessage> vetoMessages = new List<VetoMessage>();
            foreach (VetoMessage item in DbContext.VetoMessages)
            {
                if (item.DayOff != null && item.DayOff.UserID == userId) vetoMessages.Add(item);
                if (item.Debit != null && item.Debit.UserID == userId) vetoMessages.Add(item);
                if (item.Expense != null && item.Expense.UserID == userId) vetoMessages.Add(item);
            }
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
