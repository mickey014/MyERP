using BusinessERP.Data.Configuration;
using Microsoft.AspNetCore.Mvc;
using MyERP.Web.ViewModels.Modules;

namespace MyERP.Web.Controllers
{
    public class ModulesController : Controller
    {
        [Route("/Modules")]
        public IActionResult Index()
        {
            var modules = ModuleRegistry.GetModules();

            var viewModels = modules.Select(x => new ModuleCardViewModel
            {
                Title = x.Title,
                Description = x.Description,
                Icon = x.Icon,
                Url = x.Url,
                ButtonText = x.ButtonText,
                IsEnabled = x.IsEnabled,
                Badge = x.Badge,
                ColorTheme = x.ColorTheme,
                Features = x.Features
            }).ToList();

            var model = new ModuleDashboardViewModel
            {
                WelcomeMessage = "Welcome",
                UserDisplayName = User.Identity?.Name ?? "User",
                Modules = viewModels
            };

            return View(model);
        }
    }
}
