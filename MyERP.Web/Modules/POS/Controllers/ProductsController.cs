using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.POS.Controllers
{
    [Route("/POS/Products")]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel
            {
                PageTitle = "Products",
                Icon = "fa-solid fa-box",
                Message = "Product catalog management \u2014 SKUs, barcodes, categories, and pricing \u2014 will be built "
                + "in Step 11, on top of the Products and Categories entities from Step 8."
            };

            return View(model);
        }
    }
}
