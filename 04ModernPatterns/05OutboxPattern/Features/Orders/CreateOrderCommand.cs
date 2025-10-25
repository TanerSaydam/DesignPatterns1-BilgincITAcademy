using _05OutboxPattern.Context;
using _05OutboxPattern.Models;
using TS.MediatR;
using TS.Result;

namespace _05OutboxPattern.Features.Orders;

public sealed record CreateOrderCommand(
    int ProductId,
    int Quantity) : IRequest<Result<string>>;

internal sealed class CreateOrderCommandHandler(
    ApplicationDbContext dbContext) : IRequestHandler<CreateOrderCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = new()
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity
        };
        dbContext.Orders.Add(order);

        OrderOutbox orderOutbox = new()
        {
            OrderId = order.Id,
            CreatedAt = DateTimeOffset.Now,
        };
        dbContext.OrderOutboxes.Add(orderOutbox);
        await dbContext.SaveChangesAsync(cancellationToken);

        return "Order create is successful";
    }
}
