using System.Threading.Tasks;
using MM.Database;
using MM.Common.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MM.Common.Services
{

    public class EntityDeleter<TEntity> : IEntityDeleter<TEntity> where TEntity : class, IEntity
    {
        private readonly MMDbContext _db;

        public EntityDeleter(MMDbContext db)
        {
            _db = db;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await _db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            _db.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
