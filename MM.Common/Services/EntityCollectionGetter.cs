using System;
using System.Threading.Tasks;
using MM.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper.QueryableExtensions;
using System.Linq.Expressions;
using System.Collections.Generic;
using MM.Common.Contracts.Interfaces;

namespace MM.Common.Services
{
    public class EntityCollectionGetter<TEntity, TEntityViewModel> : IEntityCollectionGetter<TEntity, TEntityViewModel> where TEntity : class, IEntity
    {
        private readonly MMDbContext _db;

        public EntityCollectionGetter(MMDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TEntityViewModel>> GetAsync(
            Expression<Func<TEntity, bool>> where,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _db.Set<TEntity>().AsQueryable();
            if (where != null)
            {
                query = query.Where(where);
            }

            var mapped = query.ProjectTo<TEntityViewModel>(includeProperties);
            return await mapped.ToListAsync();
        }
    }

    public class EntityCollectionGetter<TEntity> : IEntityCollectionGetter<TEntity> where TEntity : class, IEntity
    {
        private readonly MMDbContext _db;

        public EntityCollectionGetter(MMDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            var query = _db.Set<TEntity>().AsQueryable();
            if (where != null)
            {
                query = query.Where(where);
            }
            return await query.ToListAsync();
        }
    }
}
