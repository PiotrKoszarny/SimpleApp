using Microsoft.AspNetCore.Identity;
using SimpleApp.BLL.User.Validators;
using SimpleApp.DAL.Entities;
using SimpleApp.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.BLL.User.Command.UserRegister
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, RegisterUserCommandResult>
    {
        private readonly UserManager<SimpleUser> _userManager;

        public RegisterUserCommandHandler(UserManager<SimpleUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterUserCommandResult> Execute(RegisterUserCommand command)
        {
            if (!RegisterValidators.IsValidRegisterUser(command))
            {
                throw new InvalidOperationException();
            }

            var user = new SimpleUser
            {
                Email = command.Email,
                UserName = command.Email
            };

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, command.Password);
            var result = await _userManager.CreateAsync(user);
            return new RegisterUserCommandResult { Result = result.Succeeded };
        }
    }
}
