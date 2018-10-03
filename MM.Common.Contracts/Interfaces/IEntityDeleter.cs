using System.Threading.Tasks;

namespace MM.Common.Contracts.Interfaces
{
    public interface IEntityDeleter<TEntity>
    {
        Task<TEntity> DeleteAsync(int id);
    }
}
