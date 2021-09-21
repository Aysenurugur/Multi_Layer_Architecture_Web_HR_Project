using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CustomPolicies
{
    public class CustomPasswordPolicy : PasswordValidator<User>
    {
        public async override Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, password);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (password.ToLower().Contains(user.FirstName.ToLower()) || password.ToLower().Contains(user.LastName.ToLower()))
            {
                IdentityError error = new()
                {
                    Code = "PasswordContainsFirstOrLastName",
                    Description = "İsim ve soyisim şifrede bulunamaz."
                };
                errors.Add(error);
            }
            
            if (password.Contains("123") || password.Contains("123456")) // Düzelticem 
            {
                IdentityError error = new()
                {
                    Code = "PasswordNotSequenceNumbers",
                    Description = "Şifre sıralı sayılardan oluşamaz."
                };
                errors.Add(error);
            }
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }

    }
}
