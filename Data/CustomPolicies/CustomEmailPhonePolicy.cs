using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CustomPolicies
{
    public class CustomEmailPhonePolicy : UserValidator<User>
    {
        public async override Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if (!user.Email.ToLower().EndsWith("@gmail.com"))
            {
                IdentityError error = new ()
                {
                    Code = "EmailValidation",
                    Description = "Sadece gmail uzantılı eposta adresiyle kayıt olabilirsiniz."
                };
                errors.Add(error);
            }
            if (user.Email.Length>50)
            {
                IdentityError error = new()
                {
                    Code = "EmailLength",
                    Description = "Email 50 karakterden fazla olamaz."
                };
                errors.Add(error);
            }
            if (user.PhoneNumber.Length != 11 && user.PhoneNumber.StartsWith("0"))
            {
                IdentityError error = new ()
                {
                    Code = "PhoneNumberValidation",
                    Description = "Telefon numaranız yanlış" //mesajı sonra düzeltiriz
                };
                errors.Add(error);
            }            
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
