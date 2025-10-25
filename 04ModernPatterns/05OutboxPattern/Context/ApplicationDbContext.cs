using _05OutboxPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace _05OutboxPattern.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderOutbox> OrderOutboxes { get; set; }
}
