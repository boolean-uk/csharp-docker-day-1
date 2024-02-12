using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<T> Add(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            T entity = await Get(id);
            _db.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(int id)
        {
            T entity = await _db.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new ArgumentException($"No {typeof(T).Name.ToLower()} with id: {id}");
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity, int id)
        {
            T dbEntity = await Get(id);
            dbEntity = entity;
            await _db.SaveChangesAsync();
            return dbEntity;
        }
    }
}
