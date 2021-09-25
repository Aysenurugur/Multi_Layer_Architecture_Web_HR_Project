using Core.AbstractRepositories.Generic;
using Core.Entities;
using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface IUserRepository
    {        
        Task SendVetoMessageAsync(VetoMessage vetoMessage, Guid userID);
        IEnumerable<User> List(Expression<Func<User, bool>> predicate);
        User Find(Expression<Func<User, bool>> predicate);
    }
}
