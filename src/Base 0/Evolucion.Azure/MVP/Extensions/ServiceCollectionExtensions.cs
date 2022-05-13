using MVP.Services;
using MVP.Services.Options;

namespace MVP.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            return services.Configure<SqlServerOptions>(configuration.GetSection(SqlServerOptions.OptionsName));                     
        }
        public static IServiceCollection AddAvengersService(this IServiceCollection services)
        {
            services.AddSingleton<IAvengersService, AvengersService>();

            return services;
        }
    }

}