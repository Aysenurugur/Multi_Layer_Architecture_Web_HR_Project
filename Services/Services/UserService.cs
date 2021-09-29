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

        public async Task<User> GetUserById(Guid userId)
        {
            return await userManager.FindByIdAsync(userId.ToString());
        }
        public async Task<bool> UserLoginAsync(string email, string password)
        {
            User user = await userManager.FindByEmailAsync(email);
            if (user == null || userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Failed)
            { throw new Exception("Mail adresi veya şifre hatalı, bilgilerinizi kontrol ediniz."); }
            return await Task.FromResult(true);
        }

        public async Task<bool> CheckUserPhoneNumberAsync(string phone) //bu telefon numarası bir kullanıcıya ait mi değil mi diye kontrol eder
        {
            User user = unitOfWork.User.Find(x => x.PhoneNumber == phone);
            if (user == null) { return await Task.FromResult(true); }
            return await Task.FromResult(false);
        }

        public async Task<bool> CheckUserMailAsync(string email)
        {
            User user = await userManager.FindByEmailAsync(email);
            if (user == null) return await Task.FromResult(true);
            return await Task.FromResult(false);
        }

        public async Task<bool> DeactivateAllEmployeesAsync(Guid companyId)
        {
            List<User> employees = (List<User>)unitOfWork.User.List(x => x.CompanyID == companyId);

            foreach (User item in employees) item.IsActive = false;

            return await unitOfWork.CommitAsync() > 0;
        }

        public async Task<IEnumerable<string>> RegisterAsync(User user, string password)
        {
            List<string> errors = new List<string>();

            user.UserName = user.Email.Split('@')[0]; //username hatası aldığım için çözüm olarak unique data girmek oldu.    
            user.IsActive = true;

            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded && errors.Count == 0) { return null; } //hatasız
            foreach (var error in result.Errors) { errors.Add(error.Description); }

            await unitOfWork.CommitAsync();
            return errors;
        }

        public async Task<bool> SetUserStatusAsync(Guid userId, bool status)
        {
            User user = await userManager.FindByIdAsync(userId.ToString());
            user.IsActive = status;
            return await unitOfWork.CommitAsync() > 0;
        }

        public async Task<List<string>> UpdateUserInfoAsync(User user) //custom policy hazırlanacak
        {
            List<string> errors = new List<string>();
            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors) { errors.Add(error.Description); }
            }
            await unitOfWork.CommitAsync();
            return errors;
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

        public IEnumerable<User> GetEmployees(Guid companyId, bool isActive, out int empCount)
        {
            List<User> employees = (List<User>)unitOfWork.User.List(x => x.CompanyID == companyId && x.IsActive == isActive);
            empCount = employees.Count;
            return employees;
        }

        public async Task<bool> CheckIfRoleIsManager(Guid id)
        {
            User user = await GetUserById(id);
            return await userManager.IsInRoleAsync(user, "Manager");
        }

        public async Task<User> GetUserByEmailAsync(string mail)
        {
            return await userManager.FindByEmailAsync(mail);
        }
    }
}
//salı günü 5 ekim 13.30 
