
using _05OutboxPattern.Context;
using Microsoft.EntityFrameworkCore;

namespace _05OutboxPattern;

public sealed class OrderBackgroundService(
    IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scoped = serviceScopeFactory.CreateScope();
            var srv = scoped.ServiceProvider;
            var dbContext = srv.GetRequiredService<ApplicationDbContext>();
            var outboxes = await dbContext.OrderOutboxes.Where(p => !p.IsCompleted).ToListAsync(stoppingToken);
            foreach (var item in outboxes)
            {
                try
                {
                    // mail gönder
                    item.IsCompleted = true;
                    item.ComplatedDate = DateTimeOffset.Now;
                    dbContext.Update(item);
                    await dbContext.SaveChangesAsync(stoppingToken);
                    await Task.Delay(TimeSpan.FromSeconds(10));
                }
                catch (Exception)
                {
                    await Task.Delay(TimeSpan.FromSeconds(10));
                    continue;
                }


            }
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }
}
