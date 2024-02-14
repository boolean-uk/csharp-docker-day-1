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
            this._table = _db.Set<T>();
        }
        public async Task<IEnumerable<T>> Get()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            T entity = await this._table.FindAsync(id);
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _table.Update(entity);           
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Add(T entity)
        {
            await this._table.AddAsync(entity);
            await this._db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            this._table.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
