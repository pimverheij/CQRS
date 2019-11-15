using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.QueryHandlers
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(IQuery<TResult> command);
    }

    public class QueryExecutor : IQueryExecutor
    {
        private IServiceProvider _serviceProvider;

        public QueryExecutor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> Execute<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _serviceProvider.GetService(handlerType);
            TResult result = await handler.HandleAsync((dynamic)query);

            return result;
        }
    }
}
