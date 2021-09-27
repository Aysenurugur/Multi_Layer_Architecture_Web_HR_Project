using Core.Entities.Identity;
using System;
using System.Collections.Generic;
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
        IEnumerable<User> GetEmployeesWithClosingBirthdays(Guid companyId);
        IEnumerable<User> GetActiveEmployees(Guid companyId, out int empCount);
        IEnumerable<User> GetPassiveEmployees(Guid companyId, out int empCount);
    }
}
