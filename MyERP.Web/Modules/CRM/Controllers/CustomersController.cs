using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.CRM.Controllers
{
    [Route("/CRM/Customers")]
    public class CustomersController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel
            {
                PageTitle = "Customers",
                Icon = "fa-solid fa-address-book",
                Message = "Customer profiles — contact info, purchase history from POS, activities, and notes — will be built here. This will read from the same Customers table POS uses."
            };

            return View(model);
        }
    }
}
