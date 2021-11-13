
using ASOPC.Application.Interfaces.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace ASCOPC.Infrastructure.Data
{
    public class DbTransaction : IDbTransaction
    {
        private bool _disposed;

        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction _dbTransaction;

        public DbTransaction(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public void Begin()
        {
            if (_dbTransaction == null)
                throw new ValidationException("Already opened");

            _dbTransaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_dbTransaction == null)
                throw new ValidationException("There's no transaction");

            _dbTransaction.Commit();
        }

        public void Rollback()
        {
            if (_dbTransaction == null)
                throw new ValidationException("There's no open transaction");

            _dbTransaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
                _dbContext.Dispose();

            _disposed = true;
        }
    }
}
