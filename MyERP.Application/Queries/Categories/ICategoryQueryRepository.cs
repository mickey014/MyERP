using MyERP.Application.DTOs.Response.Category;

namespace MyERP.Application.Queries.Categories
{
    public interface ICategoryQueryRepository
    {
        Task<IEnumerable<CategoryResponseDto>> GetAllAsync(
            bool includeInactive = false);
    }
}
