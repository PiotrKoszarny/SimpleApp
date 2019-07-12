using SimpleApp.Infrastructure.Query.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Infrastructure.CQRS.Query
{
    public interface IQueryDispatcher
    {
        Task<TQueryResult> Execute<TQuery, TQueryResult>(TQuery query)
            where TQuery : class, IQuery
            where TQueryResult : class, IQueryResult, new();
    }
}