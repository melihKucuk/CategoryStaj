using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CategoryStaj.DataAccess.Abstract.Generic
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CategoryDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(CategoryDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        TEntity IRepository<TEntity>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
