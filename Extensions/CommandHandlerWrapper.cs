using Venly.Dispatch.Interfaces;

namespace Venly.Dispatch.Extensions;

public class CommandHandlerWrapper<TCommand, TResult>(ICommandHandler<TCommand,TResult> handler)
    : ICommandHandlerWrapper<TResult>
{
    public Task<TResult> Handle(object command, CancellationToken cancellationToken = default)
    {
        return handler.Handle((TCommand)command, cancellationToken);
    }
}