using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SignalRApplication.Repository.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        //T FindById(string id, params Expression<Func<T, object>>[] includeProperties);

        //T FindById(int id, params Expression<Func<T, object>>[] includeProperties);

        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        int Count(params Expression<Func<T, object>>[] includeProperties);

        int Count(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);

        void AddMultiple(IList<T> entities);

        void Update(T entity);

        void UpdateMultiple(IList<T> entities);

        void Delete(T entity);

        void Delete(string id);

        void Delete(int id);

        void DeleteMultiple(IList<T> entities);

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
