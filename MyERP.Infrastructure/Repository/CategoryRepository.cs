using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyERP.Application.DTOs.Response.Category;
using MyERP.Application.Queries.Categories;
using MyERP.Domain.DomainEntities;
using MyERP.Domain.RepositoryInterface;
using MyERP.Infrastructure.Persistence;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Repository
{
    public class CategoryRepository :
        GenericRepository<CategoryDomain, Category>,
        ICategoryRepository,
        ICategoryQueryRepository
    {
        private new readonly ApplicationDbContext applicationDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
            this.applicationDbContext = applicationDbContext;
        }

        // Domain query
        public async Task<IEnumerable<CategoryDomain>> GetAllCategoryAsync(
            bool includeInactive = false
        )
        {
            var query = applicationDbContext.Categories
                .AsNoTracking();

            if(!includeInactive)
            {
                query = query.Where(c => c.IsActive);
            }

            return await query
                .OrderBy(c => c.Name)
                .ProjectTo<CategoryDomain>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // Application read query
        public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync(
            bool includeInactive = false)
        {
            var query = applicationDbContext.Categories
                .AsNoTracking();

            if (!includeInactive)
            {
                query = query.Where(c => c.IsActive);
            }

            return await query
                .OrderBy(c => c.Name)
                .Select(c => new CategoryResponseDto
                {
                    CategoryID = c.CategoryID,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    CreatedAt = c.CreatedAt,
                    ProductCount = c.Products.Count()
                })
                .ToListAsync();
        }
    }
}
