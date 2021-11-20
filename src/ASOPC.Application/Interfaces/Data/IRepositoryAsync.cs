namespace ASCOPC.Domain.Interfaces
{
    public interface IRepositoryAsync<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Entities { get; }

        Task<TEntity> GetByIdAsync(int id);

        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetPagedResponseAsync(int number, int pagesize);

        Task<TEntity> AddEntity(TEntity entity);

        Task UpdateEntity(TEntity entity);

        Task DeleteEntity(TEntity entity);

        Task<long> CountAsync();
    }
}
