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
            _table = db.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;

        }

        public async Task<T> Delete(int id)
        {
            var entity = await _table.FindAsync(id);
            _table.Remove(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Get(int id)
        {
            return _table.Find(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> Update(int id, T entity)
        {
            _table.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
