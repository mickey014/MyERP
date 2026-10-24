using MyERP.Infrastructure;

namespace MyERP.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(InfraAssemblyMarker).Assembly);

            return services;
        }
    }
}
