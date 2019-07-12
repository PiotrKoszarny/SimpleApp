using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Infrastructure.CQRS.Command
{
    public class DefaultCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _service;

        public DefaultCommandDispatcher(IServiceProvider service)
        {
            _service = service;
        }

        public virtual async Task<TCommandResult> Execute<TCommand, TCommandResult>(TCommand command)
             where TCommand : class, ICommand
            where TCommandResult : class, ICommandResult, new()
        {
            if (command == null) { throw new ArgumentNullException(); }

            var result = new TCommandResult();

            var handler = (ICommandHandler<TCommand, TCommandResult>)_service.GetService(typeof(ICommandHandler<TCommand, TCommandResult>));
            result = await handler.Execute(command);
            return result;
        }
    }
}