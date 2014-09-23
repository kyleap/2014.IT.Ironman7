using CMS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Domain;
using System.Data.Entity;

namespace CMS.DAL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal NorthwindEntities context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository()
        {
            context = new NorthwindEntities();
            dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            // 取得所有資料
            IQueryable<TEntity> query = dbSet;

            // 如果有Where條件篩選
            if (filter != null)
                query = query.Where(filter);

            // 如果有排序
            if (orderBy != null)
                return orderBy(query);
            else
                return query;
            
        }

        /// <summary>取得某筆資料</summary>
        /// <param name="id">PRIMARY KEY </param>
        /// <returns></returns>
        public TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>修改資料</summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>刪除某筆資料 by ID</summary>
        /// <param name="id">PRIMARY KEY </param>
        public void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>刪除某筆資料 by Entity</summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            //假如Entity處於Detached狀態，就先Attach起來，這樣才能順利移除
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        /// <summary>新增一筆資料</summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
