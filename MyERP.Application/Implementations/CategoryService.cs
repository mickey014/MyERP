using AutoMapper;
using MyERP.Application.Contracts;
using MyERP.Application.DTOs.Response.Category;
using MyERP.Application.Queries.Categories;
using MyERP.Domain.RepositoryInterface;
using System.Collections;

namespace MyERP.Application.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryQueryRepository categoryQueryRepository;
        private readonly IMapper mapper;

        public CategoryService(
            ICategoryQueryRepository categoryQueryRepository,
            IMapper mapper
        )
        {
           this.categoryQueryRepository = categoryQueryRepository;
           this.mapper = mapper;
        }
        public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync(
            bool includeInactive = false
        )
        {
            return await categoryQueryRepository.GetAllAsync(includeInactive);
        }
    }
}
