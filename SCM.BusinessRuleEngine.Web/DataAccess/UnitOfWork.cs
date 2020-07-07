using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace SCM.BusinessRuleEngine.Web.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        private bool disposed = false;

        private IDbContextTransaction Transaction { get; set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async System.Threading.Tasks.Task SaveAsync()
        {
            await this.dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async void BeginTransactionAsync()
        {
            if (this.Transaction == null)
            {
                this.Transaction = await this.dbContext.Database.BeginTransactionAsync().ConfigureAwait(true);
            }
        }

        public void CommitTransaction()
        {
            this.Transaction?.Commit();
        }

        /// <inheritdoc/>
        public void RollbackTransaction()
        {
            this.Transaction?.Rollback();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
