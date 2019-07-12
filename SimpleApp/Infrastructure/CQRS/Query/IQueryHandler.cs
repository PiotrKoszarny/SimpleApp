using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Infrastructure.Query.CQRS
{
    public interface IQueryHandler<in TQuery, TQueryResult>
         where TQuery : class, IQuery
         where TQueryResult : class, IQueryResult
    {
        Task<TQueryResult> HandleAsync(TQuery query);
    }
}
