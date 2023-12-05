namespace ConsoleApp.ConcurrentWorkerServiceStartup;

public class Worker2 : BackgroundService
{
    private readonly ILogger<Worker2> _logger;

    public Worker2(ILogger<Worker2> logger)
    {
        _logger = logger;
    }
    
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting Worker2 at {Time}", DateTimeOffset.Now.ToString("T"));
        await Task.Delay(3000, cancellationToken);
        await base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker2 running at: {time}", DateTimeOffset.Now);
            }
            
            await Task.Delay(10000, stoppingToken);

        }
    }
}