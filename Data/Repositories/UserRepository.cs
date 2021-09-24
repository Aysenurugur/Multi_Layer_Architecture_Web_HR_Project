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
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(ProjectIdentityDbContext context) : base(context)
        {
        }

        private ProjectIdentityDbContext DbContext
        {
            get { return context as ProjectIdentityDbContext; }
        }

        public async Task<User> GetUserByPhone(string phone)
        {
            return await DbContext.Users.Where(x => x.PhoneNumber == phone).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmail(string mail)
        {
            return await DbContext.Users.Where(x => x.Email == mail).FirstOrDefaultAsync();
        }        

        public async Task SendVetoMessageAsync(VetoMessage vetoMessage, Guid userID)
        {
            vetoMessage.VetodBy = userID;
            await context.VetoMessages.AddAsync(vetoMessage);
        }
    }
}
