using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MyERP.Domain.RepositoryInterface;
using MyERP.Infrastructure.Persistence;

namespace MyERP.Infrastructure.Repository
{
    public class GenericRepository<TDomain, TEntity> : IGenericRepository<TDomain>
        where TDomain : class
        where TEntity : class
    {
        protected readonly ApplicationDbContext applicationDbContext;
        protected readonly IMapper mapper;

        public GenericRepository(
            ApplicationDbContext applicationDbContext,
            IMapper mapper
        )
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }
        public async Task AddAsync(TDomain domain)
        {
            var entity = mapper.Map<TEntity>(domain); // domain --> entity

            await applicationDbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<int> CommitAsync()
        {
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task DetachAsync(object id)
        {
            var entity = await applicationDbContext
                .Set<TEntity>()
                .FindAsync(id);

            if (entity != null)
            {
                applicationDbContext.Entry(entity).State =
                    EntityState.Detached;
            }
        }

        public async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            return await applicationDbContext
                .Set<TEntity>()
                .AsNoTracking()
                .ProjectTo<TDomain>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<TDomain?> GetByIdAsync(object id)
        {
            var entity = await applicationDbContext
                .Set<TEntity>()
                .FindAsync(id);

            return entity == null
                ? null
                : mapper.Map<TDomain>(entity);
        }
        
        public async Task UpdateAsync(TDomain domain)
        {
            var entity = mapper.Map<TEntity>(domain);

            applicationDbContext.Set<TEntity>().Update(entity);

            await Task.CompletedTask;
        }
    }
}
