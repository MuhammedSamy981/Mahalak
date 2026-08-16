using Microsoft.EntityFrameworkCore;

namespace Mahalak;

public class MyBackgroundService : BackgroundService
{
    private readonly ILogger<MyBackgroundService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public MyBackgroundService(
        ILogger<MyBackgroundService> logger,
        IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Service started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await DoWorkAsync(stoppingToken);
                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
            }
            catch (OperationCanceledException)
            {
                // Graceful shutdown — not an error
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in background service.");
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken); // backoff
            }
        }
    }

    private async Task DoWorkAsync(CancellationToken ct)
    {
        await using var scope = _scopeFactory.CreateAsyncScope();
        var db = scope.ServiceProvider.GetRequiredService<MahalakDbContext>();
    }
}