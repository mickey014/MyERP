using MyERP.Infrastructure;
using MyERP.Infrastructure.Razor;

namespace MyERP.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // MVC + Razor
            services.AddControllersWithViews().AddRazorOptions(options =>
            {
                options.ViewLocationExpanders.Add(new ModuleViewLocationExpander());
            });

            services.AddAutoMapper(typeof(InfraAssemblyMarker).Assembly);

            return services;
        }
    }
}
