using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _table = null;

        public Repository(DataContext db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return _table.ToList();
        }
        public async Task<T> GetById(object id)
        {
            return _table.Find(id);
        }

        public async Task<T> Insert(T entity)
        {
            _table.Add(entity);
            _db.SaveChanges();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
            return entity;
        }

        public async Task<T> Delete(object id)
        {
            T entity = _table.Find(id);
            _table.Remove(entity);
            _db.SaveChanges();
            return entity;
        }

        public DbSet<T> Table { get { return _table; } }
    }
}
