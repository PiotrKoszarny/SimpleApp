using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Infrastructure.CQRS.Command
{
    public interface ICommandDispatcher
    {
        Task<TCommandResult> Execute<TCommand, TCommandResult>(TCommand command)
           where TCommand : class, ICommand
           where TCommandResult : class, ICommandResult, new();
    }
}
