using Core.AbstractRepositories;
using Core.Entities;
using Core.Entities.Identity;
using Data.Context;
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

        public bool Login(string email, string password)
        {
            User user = DbContext.Users.Where(x => x.Email == email).FirstOrDefault();
            if (user == null || user.PasswordHash != password) throw new Exception("Şifre veya mail adresi hatalı, bilgilerinizi kontrol ediniz.");
            return true;
        }

        public async Task SendVetoMessageAsync(VetoMessage vetoMessage, string userID)
        {
            vetoMessage.VetodBy = userID;
            await context.VetoMessages.AddAsync(vetoMessage);
        }
    }
}
