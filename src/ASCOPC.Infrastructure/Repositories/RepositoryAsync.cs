using ASCOPC.Domain.Interfaces;
using ASCOPC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ASCOPC.Infrastructure.Repositories
{
    public class RepositoryAsync<TEntity, TKey> : IRepositoryAsync<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly ApplicationDbContext _dbContext;
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

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbContext
                .Set<TEntity>()
                .ToListAsync();
        }

        public Task<TKey> GetByIdAsync(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetPagedResponseAsync(TKey number, TKey pagesize)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
