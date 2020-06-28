using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository
{
    public interface IRepositoryBase<T>
    {
        T GetByCondition(Expression<Func<T, bool>> expression);
        T Add(T entity);
        T Update(T entity);
        void Delete(object id);// truyền string hoặc int
        IEnumerable<T> GetByWhere(Expression<Func<T, bool>> expression);
    }
}
