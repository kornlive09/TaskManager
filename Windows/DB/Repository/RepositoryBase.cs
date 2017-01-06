using System;
using System.Data.Entity;
using System.Linq;
using DB;

namespace DB.Repository
{
    public abstract class RepositoryBase<T> where T : class 
    {
        protected TaskDbContext _context;
        protected IDbSet<T> _dbSet;

        protected RepositoryBase(TaskDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
