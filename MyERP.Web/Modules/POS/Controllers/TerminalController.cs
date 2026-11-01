using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.POS.Controllers
{
    [Route("/POS/Terminal")]
    public class TerminalController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel {
                PageTitle = "POS Terminal",
                Icon = "fa-solid fa-cash-register",
                Message = "The checkout terminal — product search, barcode entry, cart, and payment collection — will be built once the POS product and sales entities are in place."
            };

            return View(model);
        }
    }
}
