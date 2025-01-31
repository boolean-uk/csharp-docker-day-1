using System.Linq.Expressions;
using exercise.wwwapi.Data;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository<T>(DataContext _db) : IRepository<T> where T : class
    {
        
        public Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            var query = _db.Set<T>().AsQueryable();
            
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            
            return Task.FromResult(query.AsEnumerable());
        }
        
        public Task<T?> Get(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(_db.Set<T>().FirstOrDefault(predicate));
        }
        
        public Task<T?> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _db.Set<T>().AsQueryable();
            
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            
            return Task.FromResult(query.FirstOrDefault(predicate));
        }
        
        public Task<T> Add(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return Task.FromResult(entity);
        }
        
        public Task<T> Update(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
            return Task.FromResult(entity);
        }
        
        public Task<T> Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
            return Task.FromResult(entity);
        }
    }
}
