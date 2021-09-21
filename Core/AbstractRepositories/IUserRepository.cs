using Core.AbstractRepositories.Generic;
using Data.Entities.Identity;
using System.Threading.Tasks;

namespace Core.AbstractRepositories
{
    public interface IUserRepository : ICrudRepository<User>
    {
        Task<bool> Login(string email, string password);
        Task Deactivate(int userID);
    }
}
