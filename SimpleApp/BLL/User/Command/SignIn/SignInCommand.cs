using SimpleApp.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.BLL.User.Command.SignIn
{
    public class SignInCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class SignInCommandResult : ICommandResult
    {
        public bool Result { get; set; }
    }
}
