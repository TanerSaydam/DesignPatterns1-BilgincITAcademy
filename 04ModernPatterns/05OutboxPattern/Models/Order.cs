namespace _05OutboxPattern.Models;

public sealed class Order
{
    public Order()
    {
        Id = Guid.CreateVersion7();
    }
    public Guid Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
