using MyERP.Application.DTOs.Response.Category;

namespace MyERP.Web.Modules.POS.ViewModels.Categories
{
    public class CategoryIndexViewModel
    {
        public IEnumerable<CategoryResponseDto> Categories { get; set; }
            = Enumerable.Empty<CategoryResponseDto>();

        public string PageTitle { get; set; } = "Categories";

        public string PageDescription { get; set; } =
            "Organize products into groups for the catalog and terminal.";

        public int TotalCategories => Categories.Count();

        public int ActiveCategories =>
            Categories.Count(c => c.IsActive);

        public int InactiveCategories =>
            Categories.Count(c => !c.IsActive);
    }
}
