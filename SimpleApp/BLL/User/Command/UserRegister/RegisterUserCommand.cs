using SimpleApp.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.BLL.User.Command.UserRegister
{
    public class RegisterUserCommand:ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterUserCommandResult : ICommandResult
    {
        public bool Result { get; set; }
    }
}
