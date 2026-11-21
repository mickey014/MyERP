using MyERP.Application.DTOs.Response.Category;

namespace MyERP.Application.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetAllAsync(
            bool includeInactive = false
        );
    }
}
