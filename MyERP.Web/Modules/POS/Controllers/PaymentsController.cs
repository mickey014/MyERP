using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.POS.Controllers
{
    [Route("/POS/Payments")]
    public class PaymentsController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel
            {
                PageTitle = "Payments",
                Icon = "fa-solid fa-credit-card",
                Message = "Payment records across cash, GCash, and card — tied to each sale — will be built with the Payments table."
            };

            return View(model);
        }
    }
}
