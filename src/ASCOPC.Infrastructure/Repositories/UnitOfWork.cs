using ASCOPC.Domain.Interfaces;
using ASCOPC.Infrastructure.Data;
using ASOPC.Application.Interfaces.Data;
using System.Collections;

namespace ASCOPC.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private Hashtable _repositories;

        private bool _disposed;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepositoryAsync<TEntity> Repository<TEntity>()
            where TEntity : class
        {
            if (_repositories is null)
                _repositories = new();

            string type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryAsync<,>);
                var repositoryInstance = Activator.CreateInstance(
                    repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }    

            return _repositories[type] as IRepositoryAsync<TEntity>;
        }

        public int SaveChanges() =>
            _context.SaveChanges();

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken) =>
            await _context.SaveChangesAsync(cancellationToken);

        public Task RollBack()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        public IDbTransaction BeginTransaction() => 
            new DbTransaction(_context);
        

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }
    }
}
