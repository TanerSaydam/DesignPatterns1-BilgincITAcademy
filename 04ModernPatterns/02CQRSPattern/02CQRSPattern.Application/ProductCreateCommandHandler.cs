using TS.MediatR;

namespace _02CQRSPattern.Application;

internal sealed class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommandRequest>
{
    public async Task Handle(ProductCreateCommandRequest request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}