using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyERP.Domain.DomainEntities;
using MyERP.Domain.RepositoryInterface;
using MyERP.Infrastructure.Persistence;
using MyERP.Infrastructure.Persistence.Entities;

namespace MyERP.Infrastructure.Repository
{
    public class CategoryRepository : GenericRepository<CategoryDomain, Category>, ICategoryRepository
    {
        private new readonly ApplicationDbContext applicationDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<CategoryDomain>> GetAllCategoryAsync(
            bool includeInactive = false
        )
        {
            var query = applicationDbContext.Categories
                .AsNoTracking()
                //.Include(c => c.Products)
                .AsQueryable();

            if(!includeInactive)
            {
                query = query.Where(c => c.IsActive);
            }

            return await query
                .OrderBy(c => c.Name)
                .ProjectTo<CategoryDomain>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

    }
}
