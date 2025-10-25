namespace _05OutboxPattern.Models;

public sealed class OrderOutbox
{
    public int Id { get; set; }
    public Guid OrderId { get; set; }
    public bool IsCompleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? ComplatedDate { get; set; }
}
