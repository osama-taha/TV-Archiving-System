using System;
using System.Collections.Generic;

namespace TvArchiving.Domain.Infrastructure
{
    
    public interface IRepository<TEntity> where TEntity:class
    {
        void Add(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(TEntity entity);
        void Delete(Func<TEntity, Boolean> predicate);
        TEntity GetById(object Id);
        TEntity Get(Func<TEntity, Boolean> where);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);
    }
}
