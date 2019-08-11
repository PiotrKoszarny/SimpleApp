using Microsoft.AspNetCore.Identity;
using SimpleApp.DAL.Entities;
using SimpleApp.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.BLL.User.Command.SignIn
{
    public class SignInCommandHandler : ICommandHandler<SignInCommand, SignInCommandResult>
    {
        private readonly SignInManager<SimpleUser> _signInManager;

        public SignInCommandHandler(SignInManager<SimpleUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInCommandResult> Execute(SignInCommand command)
        {
            var result = await _signInManager.PasswordSignInAsync(command.Email, command.Password, false, false);
            return new SignInCommandResult
            {
                Result = result.Succeeded
            };
        }
    }
}
