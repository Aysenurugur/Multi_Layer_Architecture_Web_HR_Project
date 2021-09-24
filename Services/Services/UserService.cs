using Core.AbstractUnitOfWork;
using Core.Entities.Identity;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        readonly IUnitOfWork unitOfWork;
        Admin admin;
        UserManager<User> userManager;

        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager, IOptions<Admin> options)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            admin = options.Value;
        }

        public async Task<bool> UserLoginAsync(string email, string password)
        {
            User user = await userManager.FindByEmailAsync(email);
            if (user == null || userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Failed)
            { throw new Exception("Mail adresi veya şifre hatalı, bilgilerinizi kontrol ediniz."); }
            return await Task.FromResult(true);
        }        

        public async Task<bool> FindUserByPhoneNumber(string phone) //bu telefon numarası bir kullanıcıya ait mi değil mi diye kontrol eder
        {
            User user = await unitOfWork.User.GetUserByPhone(phone);
            if (user == null) { return await Task.FromResult(true); }
            return await Task.FromResult(false);
        }
    }
}
