using Microsoft.AspNetCore.Mvc;
using SimpleApp.BLL.User.Command.SignIn;
using SimpleApp.BLL.User.Command.UserRegister;
using SimpleApp.Infrastructure.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.PL.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public AccountController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<RegisterUserCommandResult>> Register(RegisterUserCommand registerUser)
        {
            var result = await _commandDispatcher.Execute<RegisterUserCommand, RegisterUserCommandResult>(registerUser);
            return Ok(result);
        }

        [HttpPost]
        [Route("singin")]
        public async Task<ActionResult<SignInCommandResult>> SingIn(SignInCommand registerUser)
        {
            var result = await _commandDispatcher.Execute<SignInCommand, SignInCommandResult>(registerUser);
            return Ok(result);
        }
    }
}
