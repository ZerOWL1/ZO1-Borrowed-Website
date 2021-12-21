using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ZO1.Tutorials.Core.Models.EntitiesBase;

namespace ZO1.Tutorials.Core.Cores.Infrastructures
{
    public interface IGenericRepository<TEntity> where TEntity : class, IBaseEntities
    {
        //Find
        TEntity Find(int entityId);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Finds(Expression<Func<TEntity, bool>> predicate);

        //Add
        void Add(TEntity entity);

        //Modified
        void Update(TEntity entity);

        //Delete
        void Delete(TEntity entity, bool isHardDeleted = false);
        void Delete(int entityId, bool isHardDeleted = false);

        //Get All
        IEnumerable<TEntity> GetAll();
    }
}