using conti.sb;

namespace conti.ui;

public class ServiceBusQueueListener : BackgroundService
{
    protected readonly ILogger Logger;
    private readonly IServiceProvider _serviceProvider;

    public ServiceBusQueueListener(ILogger<ServiceBusQueueListener> logger, IServiceProvider serviceProvider)
    {
        Logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var requestHandlers = scope.ServiceProvider.GetRequiredService<IEnumerable<IServiceBusListener>>();
                var tasks = requestHandlers.Select(x => x.Listen(stoppingToken));
                await Task.WhenAll(tasks);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, exception.Message);
            }
        }
    }
}