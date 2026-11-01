using Microsoft.AspNetCore.Mvc;
using MyERP.Web.Modules.Module.ViewModels;

namespace MyERP.Web.Modules.POS.Controllers
{
    [Route("/POS/Categories")]
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var model = new ModulePlaceholderViewModel
            {
                PageTitle = "Categories",
                Icon = "fa-solid fa-tags",
                Message = "Product category management will be built in Step 11 alongside the Products module."
            };

            return View(model);
        }
    }
}
