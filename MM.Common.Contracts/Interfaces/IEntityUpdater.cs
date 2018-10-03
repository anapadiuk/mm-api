using System.Threading.Tasks;

namespace MM.Common.Contracts.Interfaces
{
    public interface IEntityUpdater<TEntity>
    {
        Task<TEntity> UpdateAsync(int id, TEntity entity);
    }

    public interface IEntityUpdater<in TBindingModel, TEntity>
    {
        Task<TEntity> UpdateAsync(int id, TBindingModel model);
    }
}
