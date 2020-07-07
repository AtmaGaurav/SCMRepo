using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SCM.BusinessRuleEngine.Web.DataAccess
{
    public class GenericRepository<TEntity> : IGenericRespository<TEntity>
        where TEntity : class
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;
       
        public GenericRepository(ApplicationDbContext context)
        {
            this.dbContext = context ?? throw new ArgumentNullException(nameof(context));
            this.dbSet = context.Set<TEntity>();
        }

        public async virtual Task AddAsync(TEntity entity)
        {
            await this.dbContext.Set<TEntity>().AddAsync(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.dbContext.Entry<TEntity>(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> PagenateAsnyc(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize)
        {
            return await this.dbContext.Set<TEntity>().Where(predicate).Skip(pageIndex * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.dbContext.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties)
        {
            IQueryable<TEntity> query = dbSet;
            if (includeProperties != null)
            {
                query = includeProperties(query).AsNoTracking();
            }
            return await query.Where(predicate).ToListAsync().ConfigureAwait(true);
        }

        public virtual async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate).ConfigureAwait(true);
        }

    }
}
