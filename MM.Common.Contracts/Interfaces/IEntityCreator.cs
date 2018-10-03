using System.Threading.Tasks;

namespace MM.Common.Contracts.Interfaces
{
    public interface IEntityCreator<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);
    }

    public interface IEntityCreator<in TBindingModel, TEntity>
    {
        Task<TEntity> CreateAsync(TBindingModel model);
    }
}
