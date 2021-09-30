using Core.AbstractUnitOfWork;
using Core.Entities.Identity;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        readonly IUnitOfWork unitOfWork;
        UserManager<User> userManager;
        ICompanyService companyService;

        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager, ICompanyService companyService)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.companyService = companyService;
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
            List<User> employees = unitOfWork.User.List(x => x.CompanyID == companyId && x.IsActive).ToList();

            foreach (User item in employees) item.IsActive = false;
            await companyService.DeactivateCompany(companyId);

            return await unitOfWork.CommitAsync() > 0;
        }

        public async Task<IEnumerable<string>> RegisterAsync(User user, string password, string role)
        {
            List<string> errors = new List<string>();

            user.UserName = user.Email.Split('@')[0]; //username hatası aldığım için çözüm olarak unique data girmek oldu.    
            user.IsActive = true;
            //await userManager.AddToRoleAsync(user, role);

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

        public async Task<List<string>> UpdateUserInfoAsync(User user) 
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

        public async Task<bool> CheckIfRoleIsEmployerAsync(Guid id)
        {
            User user = await GetUserById(id);
            return await userManager.IsInRoleAsync(user, "Employer");
        }

        public async Task<User> GetUserByEmailAsync(string mail)
        {
            return await userManager.FindByEmailAsync(mail);
        }

        public string CreateRandomPassword()
        {            
            char[] letters = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z', 'X', 'W', 'Q' };
            char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] specialCharacters = { '.', ',', '/', '!', '?', '+', '-', '_' };
            string password = string.Empty;            
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                password += letters[rnd.Next(0, 31)] + letters[rnd.Next(0, 31)].ToString().ToLower() + numbers[rnd.Next(0, 9)] + specialCharacters[rnd.Next(0, 7)];
            }

            return password;
        }
    }
}
//salı günü 5 ekim 13.30 
