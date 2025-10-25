using _02CQRSPattern.Domain.Events;
using TS.MediatR;

namespace _02CQRSPattern.Application.Products;

[MyAuthorize("product-create")]
public record ProductCreateCommand(
    string Name,
    decimal Price) : IRequest<ProductCreateCommandResponse>;

public sealed class ProductCreateCommandValidator { }

public sealed record ProductCreateCommandResponse(
    string Name,
    decimal Price);

internal sealed class ProductCreateCommandHandler(ISender sender) : IRequestHandler<ProductCreateCommand, ProductCreateCommandResponse>
{
    public async Task<ProductCreateCommandResponse> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        //unqiue kontrolü
        //objeyi oluşturma
        //dbye kaydetme

        //email gönder
        //sms gönder
        await Task.CompletedTask;

        await sender.Publish(new ProductCreateDomainEvent(Guid.CreateVersion7()));

        return new ProductCreateCommandResponse(request.Name, request.Price);
    }
}