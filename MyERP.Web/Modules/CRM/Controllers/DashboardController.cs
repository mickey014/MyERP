using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.CRM.Controllers;

[Route("/CRM")]
public class DashboardController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Index()
    {
        var model = new ModuleDashboardPageViewModel
        {
            PageTitle = "CRM Dashboard",
            PageSubtitle = "Where customer relationships stand today.",
            Stats = new List<DashboardStatViewModel>
        {
            new() { Label = "Total Customers", Value = "1,245", Icon = "fa-solid fa-address-book" },
            new() { Label = "New Customers", Value = "32", Icon = "fa-solid fa-user-plus" },
            new() { Label = "Open Leads", Value = "84", Icon = "fa-solid fa-bullseye" },
            new() { Label = "Open Opportunities", Value = "32", Icon = "fa-solid fa-handshake" },
            new() { Label = "Pending Follow-ups", Value = "17", Icon = "fa-solid fa-bell" }
        }
        };

        return View(model);
    }
}
