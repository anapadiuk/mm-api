using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MM.Common.Contracts.Interfaces
{
    public interface IEntityCollectionGetter<TEntity, TEntityViewModel> where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntityViewModel>> GetAsync(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
    }

    public interface IEntityCollectionGetter<TEntity> where TEntity : class, IEntity
    {
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where);
    }
}