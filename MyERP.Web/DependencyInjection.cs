using Microsoft.AspNetCore.Identity;
using MyERP.Application;
using MyERP.Infrastructure;
using MyERP.Infrastructure.Persistence;
using MyERP.Infrastructure.Razor;
using MyERP.Web.Mappings;

namespace MyERP.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ModuleNavigationProfile).Assembly); // register automapper only on presentation layer

            // ---------------------------------------------------------------
            // ASP.NET Core Identity
            // Registered now so the schema and services exist from day one.
            // Login/registration MVC controllers and views (Step 14 -
            // Authorization in the build plan) will sit under Controllers/,
            // not Razor Pages and not an Area, to keep the whole app on one
            // consistent MVC + Modules architecture.
            // ---------------------------------------------------------------
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

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

            // Automatically register repositories
            services.Scan(scan => scan
            .FromAssemblyOf<InfraAssemblyMarker>()
            .AddClasses(classes => classes
                .Where(type => type.Name.EndsWith("Repository")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ApplicationLayerMarker).Assembly); // register automapper only on application layer

            // Automatically register Application services
            services.Scan(scan => scan
                .FromAssemblyOf<ApplicationLayerMarker>()
                .AddClasses(classes => classes
                    .Where(type => type.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
