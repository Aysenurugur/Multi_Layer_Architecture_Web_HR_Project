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

        public IEnumerable<User> List(Expression<Func<User, bool>> predicate)
        {
            return DbContext.Set<User>().Where(predicate);
        }

        public async Task SendVetoMessageAsync(VetoMessage vetoMessage, Guid userID)
        {
            vetoMessage.VetodBy = userID;
            await DbContext.VetoMessages.AddAsync(vetoMessage);
        }
    }
}
