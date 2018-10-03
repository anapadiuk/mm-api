using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MM.Common.Contracts.Interfaces
{
    public interface IEntityGetter<TEntity, TViewModel>
    {
        Task<TViewModel> GetAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties);
    }

    public interface IEntityGetter<TEntity>
    {
        Task<TEntity> GetAsync(int id);
    }
}
