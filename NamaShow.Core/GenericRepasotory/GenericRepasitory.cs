using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NamaShow.Core.GenericRepasotory
{
    class GenericRepasitory<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbset;
        private DbContext _db;
        public GenericRepasitory(DbContext db, DbSet<TEntity> dbset)
        {
            _db = db;
            _dbset = _db.Set<TEntity>();
        }

        public virtual TEntity GetById(object Id)
        {
            return _dbset.Find(Id);
        }
        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> where = null) {

            IQueryable<TEntity> q = _dbset;
            if (where != null)
            {
                q = q.Where(where);
            }
            return q.ToList();
        }
        public void Add (TEntity entity)
        {
            _dbset.Add(entity);

        }

        public virtual void Delete (object Id)
        {
           
        }

    }
}