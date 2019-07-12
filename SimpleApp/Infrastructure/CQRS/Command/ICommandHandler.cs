using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Infrastructure.CQRS.Command
{
    public interface ICommandHandler<in TCommand,TCommandResult>
        where TCommand: class, ICommand
    {
        Task<TCommandResult> Execute(TCommand command);
    }
}
