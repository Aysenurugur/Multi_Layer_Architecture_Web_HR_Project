using Core.AbstractUnitOfWork;
using Core.Entities.Identity;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        readonly IUnitOfWork unitOfWork;
        UserManager<User> userManager;

        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public async Task<bool> UserLoginAsync(string email, string password)
        {
            User user = await userManager.FindByEmailAsync(email);
            if (user == null || userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Failed)
            { throw new Exception("Mail adresi veya şifre hatalı, bilgilerinizi kontrol ediniz."); }
            return await Task.FromResult(true);
        }

        public async Task<bool> FindUserByPhoneNumberAsync(string phone) //bu telefon numarası bir kullanıcıya ait mi değil mi diye kontrol eder
        {
            User user = unitOfWork.User.Find(x => x.PhoneNumber == phone);
            if (user == null) { return await Task.FromResult(true); }
            return await Task.FromResult(false);
        }

        public async Task<bool> DeactivateAllEmployeesAsync(Guid companyId)
        {
            List<User> employees = (List<User>)unitOfWork.User.List(x => x.CompanyID == companyId);

            foreach (User item in employees) item.IsActive = false;

            return await unitOfWork.CommitAsync() > 0;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            user.Id = new Guid();
            await userManager.CreateAsync(user);
            return await unitOfWork.CommitAsync() > 0;
        }

        public async Task<bool> SetUserStatusAsync(Guid userId, bool status)
        {
            User user = await userManager.FindByIdAsync(userId.ToString());
            user.IsActive = status;
            return await unitOfWork.CommitAsync() > 0;
        }

        public async Task<bool> UpdateUserInfoAsync(Guid userId)
        {
            User user = await userManager.FindByIdAsync(userId.ToString());
            await userManager.UpdateAsync(user);
            return await unitOfWork.CommitAsync() > 0;
        }

        public IEnumerable<User> GetUsers()
        {
            return userManager.Users;
        }

        public IEnumerable<User> GetEmployeesWithClosingBirthdays(Guid companyId) 
        {
            List<User> employees = new List<User>();
            foreach (User item in unitOfWork.User.List(x => x.CompanyID == companyId))
            {
                DateTime today = DateTime.Today;
                DateTime next = new DateTime(today.Year, item.BirthDate.Value.Month, item.BirthDate.Value.Day);
                if (next < today) next = next.AddYears(1);
                int numDays = (next - today).Days;
                if (numDays <= 30) employees.Add(item);
            }
            return employees;
        }

        public IEnumerable<User> GetActiveEmployees(Guid companyId, out int empCount)
        {
            List<User> employees = (List<User>)unitOfWork.User.List(x => x.CompanyID == companyId && x.IsActive);
            empCount = employees.Count;
            return employees;
        }

        public IEnumerable<User> GetPassiveEmployees(Guid companyId, out int empCount)
        {
            List<User> employees = (List<User>)unitOfWork.User.List(x => x.CompanyID == companyId && !x.IsActive);
            empCount = employees.Count;
            return employees;
        }
    }
}
