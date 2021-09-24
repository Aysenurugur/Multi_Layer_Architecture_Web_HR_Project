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
        Task<bool> FindUserByPhoneNumber(string phone);
    }
}
