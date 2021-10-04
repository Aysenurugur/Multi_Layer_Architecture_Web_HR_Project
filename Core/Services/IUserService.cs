using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task<User> GetUserById(Guid userId);
        Task<bool> UserLoginAsync(string email, string password);
        Task<bool> CheckUserPhoneNumberAsync(string phone);
        Task<bool> CheckUserMailAsync(string email);
        Task<bool> DeactivateAllEmployeesAsync(Guid companyId);
        Task<IEnumerable<string>> RegisterAsync(User user, string password, string role);
        Task<bool> SetUserStatusAsync(Guid userId, bool status);
        Task<bool> CheckIfRoleIsEmployerAsync(Guid id);
        Task<List<string>> UpdateUserInfoAsync(User user);
        IEnumerable<User> GetUsers();
        Task<IEnumerable<User>> GetEmployeesWithClosingBirthdays(Guid companyId);
        IEnumerable<User> GetEmployees(Guid companyId, bool isActive, out int empCount);
        Task<User> GetUserByEmailAsync(string mail);
        string CreateRandomPassword();
    }
}
