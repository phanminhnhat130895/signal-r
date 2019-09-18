using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SignalRApplication.Repository.Infrastructure
{
    public class EFRepository<T> : IRepository<T>, IDisposable where T : class
    {
        private EFDbContext _context;

        private DbSet<T> _dbSet;

        public EFRepository(EFDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public DbSet<T> DbSet
        {
            get
            {
                if(_dbSet == null)
                {
                    _dbSet = _context.Set<T>();
                }
                return _dbSet as DbSet<T>;
            }
        }

        public virtual IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if(includeProperties != null)
            {
                foreach(var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public virtual IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = FindAll(includeProperties);
            return items.Where(predicate);
        }

        public virtual T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }

        public int Count(params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).Count();
        }

        public int Count(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(predicate, includeProperties).Count();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddMultiple(IList<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateMultiple(IList<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Delete(string id)
        {
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteMultiple(IList<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
