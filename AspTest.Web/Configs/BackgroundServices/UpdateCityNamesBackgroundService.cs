using AspTest.ServiceLayer.Counties.Contracts;

namespace AspTest.Configs.BackgroundServices;

public class UpdateCityNamesBackgroundService(
    IServiceProvider serviceProvider,
    ILogger<UpdateCityNamesBackgroundService> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.Now;
            var nextRunTime = DateTime.Today.AddHours(8);

            if (now > nextRunTime)
                nextRunTime = nextRunTime.AddDays(1);

            var delay = nextRunTime - now;
            logger.LogInformation("UpdateCityNamesBackgroundService is delaying for {Delay} until next run at {NextRunTime}", delay, nextRunTime);
            await Task.Delay(delay, stoppingToken);

            try
            {
                logger.LogInformation("UpdateCityNamesBackgroundService started at: {Time}", DateTime.Now);

                using var scope = serviceProvider.CreateScope();
                var cityService = scope.ServiceProvider
                    .GetRequiredService<CountyService>();
                await cityService.AddStarToStartOfAllCountiesName();
                
                logger.LogInformation("UpdateCityNamesBackgroundService finished successfully at: {Time}", DateTime.Now);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "UpdateCityNamesBackgroundService failed at: {Time}", DateTime.Now);
            }
        }
    }
}