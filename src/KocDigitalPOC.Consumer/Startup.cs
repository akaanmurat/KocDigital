using KocDigitalPOC.Consumer.Consumers;
using KocDigitalPOC.Core;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KocDigitalPOC.Consumer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();

            services.AddMassTransit(configure =>
            {
                configure.AddConsumer<DataFrameCreatedConsumer>();
                configure.AddBus(context => Bus.Factory.CreateUsingRabbitMq(config =>
                {
                    config.Host("kocdigitalpoc.rabbitmq", "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                    config.ReceiveEndpoint(RabbitMqConstants.DataFrameCreatedQueue, e =>
                    {
                        e.ConfigureConsumer<DataFrameCreatedConsumer>(context);
                    });
                }));
            });
            services.AddMassTransitHostedService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
