using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.POS.Controllers
{
    [Route("/POS/Returns")]
    public class ReturnsController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel
            {
                PageTitle = "Returns",
                Icon = "fa-solid fa-rotate-left",
                Message = "Processing sale returns and refunds will be built with the SaleReturns and SaleReturnItems tables."
            };

            return View(model);
        }
    }
}
