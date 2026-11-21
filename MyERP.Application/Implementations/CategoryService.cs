using AutoMapper;
using MyERP.Application.Contracts;
using MyERP.Application.DTOs.Response.Category;
using MyERP.Domain.RepositoryInterface;
using System.Collections;

namespace MyERP.Application.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper
        )
        {
           this.categoryRepository = categoryRepository;
           this.mapper = mapper;
        }
        public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync(
            bool includeInactive = false
        )
        {
            var categories = await categoryRepository
                .GetAllCategoryAsync(includeInactive);

            return mapper.Map<IEnumerable<CategoryResponseDto>>(categories);
        }
    }
}
