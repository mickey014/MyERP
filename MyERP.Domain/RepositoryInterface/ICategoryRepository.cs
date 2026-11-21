using MyERP.Domain.DomainEntities;

namespace MyERP.Domain.RepositoryInterface
{
    public interface ICategoryRepository : IGenericRepository<CategoryDomain>
    {
        Task<IEnumerable<CategoryDomain>> GetAllCategoryAsync(
            bool includeInactive = false
        );
    }
}
