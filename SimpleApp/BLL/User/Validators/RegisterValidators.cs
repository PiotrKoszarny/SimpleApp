using Microsoft.AspNetCore.Identity;
using SimpleApp.BLL.User.Command.UserRegister;
using SimpleApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.BLL.User.Validators
{
    public static class RegisterValidators
    {
        public static bool IsValidRegisterUser(RegisterUserCommand user)
        {
            return !string.IsNullOrEmpty(user.Password)
                    && !string.IsNullOrEmpty(user.ConfirmPassword)
                    && !string.IsNullOrEmpty(user.Email)
                    && user.Password.Equals(user.ConfirmPassword)
                    && new EmailAddressAttribute().IsValid(user.Email);
        }
    }
}
