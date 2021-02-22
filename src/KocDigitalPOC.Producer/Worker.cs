using System;
using MassTransit;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using KocDigitalPOC.Core.MessageContracts;
using KocDigitalPOC.Producer.Configuration;
using Microsoft.Extensions.Options;

namespace KocDigitalPOC.Producer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ProducerConfig _config;

        public Worker(ILogger<Worker> logger, IPublishEndpoint publishEndpoint, IOptions<ProducerConfig> config)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
            _config = config.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _publishEndpoint.Publish<IDataFrameCreated>(new DataFrameCreated
                    {
                        Id = Guid.NewGuid().ToString(),
                        LocationId = _config.LocationId,
                        Title = "Communication Request Started",
                        Completed = false
                    });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                await Task.Delay(_config.IntervalTime * 1000, stoppingToken);
            }

            _logger.LogInformation("Worker stopped at: {time}", DateTimeOffset.Now);
        }
    }
}