using MassTransit;
using Microsoft.Extensions.Hosting;
using KocDigitalPOC.Core.MessageContracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using KocDigitalPOC.Producer.Configuration;
using System;

namespace KocDigitalPOC.Producer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    var env = context.HostingEnvironment;
                    if (string.IsNullOrEmpty(environmentName))
                        environmentName = env.EnvironmentName;
                
                    builder.SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<ProducerConfig>(hostContext.Configuration.GetSection("ProducerConfig"));

                    services.AddMassTransit(configure =>
                    {
                        configure.UsingRabbitMq((context, config) =>
                        {
                            config.Host("kocdigitalpoc.rabbitmq", "/", host =>
                            {
                                host.Username("guest");
                                host.Password("guest");
                            });
                        });

                        configure.AddRequestClient<IDataFrameCreated>();
                    });
                    services.AddMassTransitHostedService();

                    services.AddHostedService<Worker>();
                });
    }
}