using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ZO1.Tutorials.Core.Contexts;
using ZO1.Tutorials.Core.Models.EntitiesBase;
using ZO1.Tutorials.Core.Models.Enums;

namespace ZO1.Tutorials.Core.Cores.Infrastructures
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IBaseEntities
    {
        protected readonly BorrowedContext Context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(BorrowedContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual TEntity Find(int entityId)
        {
            return _dbSet.Find(entityId);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual IEnumerable<TEntity> Finds(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity, bool isHardDeleted = false)
        {
            if (isHardDeleted == false)
            {
                entity.Status = Status.IsDeleted;
                Context.Entry(entity).State = EntityState.Modified;
                return;
            }

            _dbSet.Remove(entity);
        }

        public virtual void Delete(int entityId, bool isHardDeleted = false)
        {
            var entity = Find(e => e.Id == entityId);
            if (entity == null) return;

            if (isHardDeleted == false)
            {
                entity.Status = Status.IsDeleted;
                Context.Entry(entity).State = EntityState.Modified;
                return;
            }

            _dbSet.Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}