using TS.MediatR;

namespace _02CQRSPattern.Application.Behaviors;

public sealed class ValidateBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken = default)
    {
        // kodun başına
        var res = await next();

        //kodun sonuna

        return res;
    }
}


public sealed class ValidateBehavior<TRequest> : IPipelineBehavior<TRequest>
    where TRequest : IRequest
{
    public async Task Handle(TRequest request, RequestHandlerDelegate next, CancellationToken cancellationToken = default)
    {
        // kodun başına
        await next();
    }
}
