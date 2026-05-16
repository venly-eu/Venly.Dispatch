using Venly.Dispatch.Interfaces;
using Venly.Dispatch.Interfaces.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Venly.Dispatch.Services;

public class Dispatcher(IServiceProvider serviceProvider) : IDispatcher
{
    public async Task<TResult> DispatchAsync<TResult>
        (ICommand<TResult> command, CancellationToken cancellationToken = default)
    {
        var wrapper = serviceProvider.GetRequiredService<ICommandHandlerWrapper<TResult>>();
        return await wrapper.Handle(command, cancellationToken);
    }

    public async Task<TResult> DispatchAsync<TResult>
        (IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        var wrapper = serviceProvider.GetRequiredService<IQueryHandlerWrapper<TResult>>();
        return await wrapper.Handle(query, cancellationToken);
    }
}