using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _table;
        public Repository(DataContext db)
        {
            _db = db;
            _table = _db.Set<T>();

        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> AddNewObject(T entity)
        {
            await _table.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteObject(int id)
        {
            T entity = _table.Find(id);
            _table.Remove(entity);
            _db.SaveChanges();
            return entity;
        }

        public async Task<T> GetById(int id)
        {
            return _table.Find(id);
        }

        public async Task<T> Update(T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
