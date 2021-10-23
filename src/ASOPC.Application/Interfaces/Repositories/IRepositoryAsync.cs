namespace ASCOPC.Domain.Interfaces
{
    public interface IRepositoryAsync<TEntity, TKey> 
        where TEntity : class, IEntity<TKey>
    {
        IQueryable<TEntity> Entities { get; }

        Task<TKey> GetByIdAsync(TKey id);

        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetPagedResponseAsync(TKey number, TKey pagesize);

        Task<TEntity> AddEntity(TEntity entity);

        Task UpdateEntity(TEntity entity);

        Task DeleteEntity(TEntity entity);

        Task<long> CountAsync();
    }
}
