using TS.MediatR;

namespace _02CQRSPattern.Domain.Events;

public class ProductCreateDomainEvent : INotification
{
    public Guid Id { get; }

    public ProductCreateDomainEvent(Guid id)
    {
        Id = id;
    }
}

public class ProductCreateEmailDomainEvent : INotificationHandler<ProductCreateDomainEvent>
{
    public async Task Handle(ProductCreateDomainEvent notification, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("ProductCreateEmailDomainEvent: {0}", DateTime.Now);
        await Task.CompletedTask;
    }
}

public class ProductCreateSmsDomainEvent : INotificationHandler<ProductCreateDomainEvent>
{
    public async Task Handle(ProductCreateDomainEvent notification, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("ProductCreateSmsDomainEvent: {0}", DateTime.Now);
        await Task.CompletedTask;
    }
}