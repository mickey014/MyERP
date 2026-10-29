using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.POS.ViewModels;

namespace MyERP.Web.Modules.POS.Controllers
{
    [Route("/POS")]
    public class DashboardController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new ModuleDashboardPageViewModel
            {
                PageTitle = "POS Dashboard",
                PageSubtitle = "Today's activity across the register.",
                Stats = new List<DashboardStatViewModel>
            {
                new() { Label = "Today's Sales", Value = "\u20b1125,450.00", Icon = "fa-solid fa-sack-dollar" },
                new() { Label = "Today's Transactions", Value = "245", Icon = "fa-solid fa-receipt" },
                new() { Label = "Total Products", Value = "1,245", Icon = "fa-solid fa-box" },
                new() { Label = "Low Stock", Value = "18", Icon = "fa-solid fa-triangle-exclamation" }
            }
            };

            return View(model);
        }
    }
}
