using Core.AbstractRepositories.Generic;
using Core.Entities;
using Core.Entities.Identity;
using System;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface IUserRepository : ICrudRepository<User>
    {        
        Task SendVetoMessageAsync(VetoMessage vetoMessage, Guid userID);
        Task<User> GetUserByEmail(string mail);
        Task<User> GetUserByPhone(string phone);
    }
}
