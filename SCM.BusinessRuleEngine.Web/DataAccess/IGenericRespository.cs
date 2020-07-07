using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SCM.BusinessRuleEngine.Web.DataAccess
{
    public interface IGenericRespository<TEntity>
        where TEntity : class
    {
        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        Task<IEnumerable<TEntity>> PagenateAsnyc(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);

        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties);

        TEntity GetById(Expression<Func<TEntity, bool>> id);

    }
}
