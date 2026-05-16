using Venly.Dispatch.Interfaces;

namespace Venly.Dispatch.Extensions;

public class QueryHandlerWrapper<TQuery, TResult>(IQueryHandler<TQuery, TResult> handler) : IQueryHandlerWrapper<TResult>
{
    public Task<TResult> Handle(object query, CancellationToken cancellationToken = default)
    {
        return handler.Handle((TQuery)query, cancellationToken);
    }
}
