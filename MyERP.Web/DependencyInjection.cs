using MyERP.Application;
using MyERP.Infrastructure;
using MyERP.Infrastructure.Razor;
using MyERP.Web.Mappings;

namespace MyERP.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ModuleNavigationProfile).Assembly); // register automapper only on presentation layer

            return services;
        }

        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // MVC + Razor
            services.AddControllersWithViews().AddRazorOptions(options =>
            {
                options.ViewLocationExpanders.Add(new ModuleViewLocationExpander());
            });

            services.AddAutoMapper(typeof(InfraAssemblyMarker).Assembly); // register automapper only on infrastructure layer

            return services;
        }

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ApplicationLayerMarker).Assembly); // register automapper only on application layer

            return services;
        }
    }
}
