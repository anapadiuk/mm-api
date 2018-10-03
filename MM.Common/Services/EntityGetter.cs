using System;
using System.Threading.Tasks;
using MM.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;
using MM.Common.Contracts.Interfaces;

namespace MM.Common.Services
{
    public class EntityGetter<TEntity, TEntityViewModel> : IEntityGetter<TEntity, TEntityViewModel> where TEntity : class, IEntity
    {
        private readonly MMDbContext _db;

        public EntityGetter(MMDbContext db)
        {
            _db = db;
        }

        public async Task<TEntityViewModel> GetAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _db.Set<TEntity>().Where(x => x.Id == id);
            var mapped = query.ProjectTo<TEntityViewModel>(includeProperties);
            return await mapped.FirstOrDefaultAsync();
        }
    }

    public class EntityGetter<TEntity> : IEntityGetter<TEntity> where TEntity : class, IEntity
    {
        private readonly MMDbContext _db;

        public EntityGetter(MMDbContext db)
        {
            _db = db;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _db.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
