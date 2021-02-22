using KocDigitalPOC.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KocDigitalPOC.WebApi.Extensions
{
    public static class DatabaseCreator
    {
        public static void CreateDatabaseIfNotExist(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<KocDigitalDbContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}