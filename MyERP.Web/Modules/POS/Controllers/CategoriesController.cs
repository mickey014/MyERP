using Microsoft.AspNetCore.Mvc;
using MyERP.Application.Contracts;
using MyERP.Web.Modules.POS.ViewModels.Categories;

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

            var viewModel = new CategoryIndexViewModel
            {
                Categories = categories
            };

            return View(viewModel);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
