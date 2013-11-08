using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data;

namespace TvArchiving.Domain.Infrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private TvArchivingDbContext dataContext;
        private readonly IDbSet<T> dbset;
        protected Repository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }
        protected IDatabaseFactory DatabaseFactory { get; private set; }
        protected TvArchivingDbContext DataContext { get { return dataContext ?? (dataContext = DatabaseFactory.Get()); } }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(T entityToUpdate)
        {
            dbset.Attach(entityToUpdate);
            dataContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        public virtual void Delete(Func<T, Boolean> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbset.Remove(obj);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(object id)
        {
            return dbset.Find(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetMany(Func<T, bool> where)
        {
            var i = dbset.AsQueryable().Where(where).ToList();
            return i;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T Get(Func<T, Boolean> where)
        {
            return dbset.AsQueryable().Where(where).FirstOrDefault<T>();
        }
    }

}
