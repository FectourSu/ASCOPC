using ASCOPC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASOPC.Application.Interfaces.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepositoryAsync<TEntity> Repository<TEntity>()
            where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangeAsync(CancellationToken cancellationToken);
        Task RollBack();
        IDbTransaction BeginTransaction();
    }
}
