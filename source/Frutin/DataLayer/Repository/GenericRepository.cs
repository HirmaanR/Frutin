using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DataLayer
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private FrutinContext _db;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(FrutinContext db)
        {
            this._db = db;
            this._dbSet = db.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (where != null)
                query = query.Where(where);

            if (sort != null)
                query = query.OrderBy(sort);

            if (includes != "")
            {
                foreach (string include in includes.Split(','))
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public virtual void Update(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity); _dbSet.Attach(entity);

            _db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

    }
}
