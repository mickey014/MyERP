using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.POS.Controllers
{
    [Route("/POS/Inventory")]
    public class InventoryController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel
            {
                PageTitle = "Inventory",
                Icon = "fa-solid fa-warehouse",
                Message = "Stock levels and inventory transactions (purchases, sales, adjustments, transfers) will be built with the Inventory and InventoryTransactions tables."
            };

            return View(model);
        }
    }
}
