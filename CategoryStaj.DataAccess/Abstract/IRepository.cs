using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CategoryStaj.DataAccess.Abstract.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
