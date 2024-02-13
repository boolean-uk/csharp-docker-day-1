using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }

        public virtual async Task<T> Add(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            int status = await _db.SaveChangesAsync();
            if (status <= 0) {
                throw new ArgumentException($"An error occured adding {typeof(T).Name.ToLower()} to the database");
            }
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            T entity = await Get(id);
            _db.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Get(int id, string? include=null)
        {
            T entity;
            if (include != null)
            {
                entity = await _db.Set<T>()
                    .Include(include)
                    .FirstOrDefaultAsync(x => x.Id == id)
                    ?? throw new ArgumentException($"No {typeof(T).Name.ToLower()} with id: {id}");
            } else
            {
                entity = await _db.Set<T>()
                    .FirstOrDefaultAsync(x => x.Id == id)
                    ?? throw new ArgumentException($"No {typeof(T).Name.ToLower()} with id: {id}");
            }
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll(string? include = null)
        {
            if (include != null)
            {
                return await _db.Set<T>()
                .Include(include)
                .ToListAsync();
            } else
            {
                return await _db.Set<T>().ToListAsync();
            }
            
        }

        public async Task<T> Update(T entity, int id)
        {
            T dbEntity = await Get(id);
            entity.Id = id;
            _db.Set<T>().Attach(dbEntity);
            _db.Entry(dbEntity).CurrentValues.SetValues(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
