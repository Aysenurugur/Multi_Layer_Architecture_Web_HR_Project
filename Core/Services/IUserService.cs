using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task<bool> UserLoginAsync(string email, string password);
        Task<bool> FindUserByPhoneNumberAsync(string phone);
        Task<bool> DeactivateAllEmployeesAsync(Guid companyId);
        Task<bool> RegisterAsync(User user);
        Task<bool> SetUserStatusAsync(Guid userId, bool status);
        IEnumerable<User> GetUsers();
    }
}
