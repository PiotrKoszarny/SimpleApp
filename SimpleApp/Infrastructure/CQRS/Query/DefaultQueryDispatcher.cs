using SimpleApp.Infrastructure.Query.CQRS;
using System;
using System.Threading.Tasks;

namespace SimpleApp.Infrastructure.CQRS.Query
{
    public class DefaultQueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider service;

        public DefaultQueryDispatcher(IServiceProvider service)
        {
            this.service = service;
        }

        public async Task<TQueryResult> Execute<TQuery, TQueryResult>(TQuery query)
            where TQuery : class, IQuery
            where TQueryResult : class, IQueryResult, new()
        {
            if (query == null) { throw new ArgumentNullException(); }

            var result = new TQueryResult();

            IQueryHandler<TQuery, TQueryResult> handler;
            handler = (IQueryHandler<TQuery, TQueryResult>)service.GetService(typeof(IQueryHandler<TQuery, TQueryResult>));
            result = await handler.HandleAsync(query);
            return result;
        }
    }
}
