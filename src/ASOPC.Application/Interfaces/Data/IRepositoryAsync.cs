namespace ASCOPC.Domain.Interfaces
{
    public interface IRepositoryAsync<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByIdAsync(string id);

        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetPagedResponseAsync(int number, int pagesize);

        Task<TEntity> AddEntity(TEntity entity);

        Task UpdateEntity(TEntity entity, int id);

        Task DeleteEntity(TEntity entity);

        Task<long> CountAsync();
    }
}
