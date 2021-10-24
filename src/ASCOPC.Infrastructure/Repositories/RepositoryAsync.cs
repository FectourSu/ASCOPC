using ASCOPC.Domain.Interfaces;
using ASCOPC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ASCOPC.Infrastructure.Repositories
{
    public class RepositoryAsync<TEntity, TKey> : IRepositoryAsync<TEntity>
        where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        public RepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public IQueryable<TEntity> Entities => throw new NotImplementedException();

        public async Task<long> CountAsync() => 
            await _dbContext.Set<TEntity>().CountAsync();

        public async Task<TEntity> AddEntity(TEntity entity) 
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public Task DeleteEntity(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<TEntity>> GetAllAsync() =>
            await _dbContext.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(int id) => 
            await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task<List<TEntity>> GetPagedResponseAsync(int pageNumber, int pageSize) =>
            await _dbContext
                .Set<TEntity>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

        public Task UpdateEntity(TEntity entity)
        {
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }
    }
}
