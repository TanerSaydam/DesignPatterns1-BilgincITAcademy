namespace _02CQRSPattern.WebAPI;

public class MyBackground(IServiceScopeFactory serviceScopeFactory) : BackgroundService
{

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scoped = serviceScopeFactory.CreateScope();
        var srv = scoped.ServiceProvider;
        var test = srv.GetRequiredService<Test>();
        await Task.CompletedTask;
    }
}
