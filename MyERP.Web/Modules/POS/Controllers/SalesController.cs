using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.POS.Controllers
{
    [Route("/POS/Sales")]
    public class SalesController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel
            {
                PageTitle = "Sales",
                Icon = "fa-solid fa-receipt",
                Message = "Sales history, invoice lookup, and order details will be built once the Sales and SaleItems tables are in place."
            };

            return View(model);
        }
    }
}
