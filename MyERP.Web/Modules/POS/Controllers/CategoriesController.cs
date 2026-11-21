using Microsoft.AspNetCore.Mvc;
using MyERP.Application.Contracts;

namespace MyERP.Web.Modules.POS.Controllers
{
    [Route("/POS/Categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoriesController(
            ICategoryService categoryService
        )
        {
            this.categoryService = categoryService;    
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllAsync(includeInactive: true);

            return Json(categories);

            return View(categories);
        }
    }
}
