using System;
using System.Linq;
using System.Linq.Expressions;

namespace Lucca.Domain.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Insert(T entity);

        void Update(T entity);

        void Delate(T entity);
    }
}