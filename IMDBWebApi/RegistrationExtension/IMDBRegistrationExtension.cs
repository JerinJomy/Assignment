using IMDBDataStore.Configs;
using IMDBDataStore.Schema;
using IMDBDataStore.Schema.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IMDBWebApi.RegistrationExtension
{
    public static class IMDBRegistrationExtension
    {
        public static void AddIMDBServices(this IServiceCollection service ,IConfiguration configuration)
        {
            service.Configure<DatabaseConfigurations>(configuration.GetSection("DatabaseConfigurations"));
            service.AddDbContext<IMDBContext>(options => options.UseSqlServer(configuration["DatabaseConfigurations:ConnectionString"]));
            service.AddHostedService<SchemaInitializer>();
        }
    }
}
