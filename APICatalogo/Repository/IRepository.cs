using System;
using System.Linq;
using System.Linq.Expressions;

namespace APICatalogo.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T GetbyId(Expression<Func<T, bool>> predicate);
        void Add(T enity);
        void Update(T entity);
        void Delete(T entity);
    }
}
