using AutoMapper;
using MM.Common.Contracts.Interfaces;
using MM.Database;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MM.Common.Services
{
    public class EntityUpdater<TEntityBindingModel, TEntity> : IEntityUpdater<TEntityBindingModel, TEntity> where TEntity : class, IEntity
    {
        private readonly MMDbContext _db;

        public EntityUpdater(MMDbContext db)
        {
            _db = db;
        }

        public async Task<TEntity> UpdateAsync(int id, TEntityBindingModel model)
        {
            var entity = await _db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            var dest = (TEntity)Mapper.Map(model, entity, typeof(TEntityBindingModel), typeof(TEntity));
            _db.Update(dest);
            await _db.SaveChangesAsync();
            return dest;
        }
    }
}
