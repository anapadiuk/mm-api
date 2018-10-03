using AutoMapper;
using System.Threading.Tasks;
using MM.Database;
using MM.Common.Contracts.Interfaces;

namespace MM.Common.Services
{

    public class EntityCreator<TEntity> : IEntityCreator<TEntity> where TEntity : class, IEntity
    {
        private readonly MMDbContext _db;

        public EntityCreator(MMDbContext db)
        {
            _db = db;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }

    public class EntityCreator<TBindingModel, TEntity> : EntityCreator<TEntity>, IEntityCreator<TBindingModel, TEntity> where TEntity : class, IEntity
    {
        public EntityCreator(MMDbContext db): 
            base(db)
        {

        }

        public async Task<TEntity> CreateAsync(TBindingModel model)
        {
            var entity = Mapper.Map<TBindingModel, TEntity>(model);
            return await CreateAsync(entity);
        }
    }

}
