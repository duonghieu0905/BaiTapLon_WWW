using EntityFrameworks.AccessModel;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NewsRepository<T> : INewsRepository<T> where T:class
    {
        private NewsDBContext dbContext;
        public NewsRepository()
        {
            dbContext = new NewsDBContext();
        }
        public T Add(T entity)
        {
           var result= dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return result;
        }

        public void Delete(object id)
        {
            var exits = dbContext.Set<T>().Find(id);
            if (exits != null)
            {
                dbContext.Set<T>().Remove(exits);
                dbContext.SaveChanges();
            }
        }

        public T GetByCondition(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().FirstOrDefault(expression);

        }

        public T GetById(object id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetByWhere(Expression<Func<T, bool>> expression)
        {
            return dbContext.Set<T>().Where(expression);
        }

        public T Update(T entity)
        {
            var result = dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified; //xem lại
            dbContext.SaveChanges();
            return result;
        }
    }
}
