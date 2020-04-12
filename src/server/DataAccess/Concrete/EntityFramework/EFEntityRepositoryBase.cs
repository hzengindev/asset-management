using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFEntityRepositoryBase<TEntity> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        private DbContext dbContext;

        public EFEntityRepositoryBase(DbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return dbContext.Set<TEntity>().SingleOrDefault(filter);
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? dbContext.Set<TEntity>().ToList()
                : dbContext.Set<TEntity>().Where(filter).ToList();
        }

        public void Add(TEntity entity)
        {
            var addedEntity = dbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = dbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
        }
    }
}