using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _db;
        private DbSet<T> _dbSet;

        public Repository(DataContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public async Task<T> Insert(T entity)
        {
            if (entity != null)
            {
                await _dbSet.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            else
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }
        }

        public async Task<IEnumerable<T>> SelectAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> SelectById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T?> Update(int id, T entity)
        {
            // Find the existing entity by ID
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity == null)
            {
                return null;
            }

            // Update properties of the existing entity with the values from the new entity
            foreach (var property in entity.GetType().GetProperties())
            {
                var newValue = property.GetValue(entity);
                var existingValue = property.GetValue(existingEntity);

                // Check if the value is different before updating
                if ((property.Name != "Id") && !object.Equals(newValue, existingValue))
                {
                    property.SetValue(existingEntity, newValue);
                }
            }

            // Save changes to the database
            await _db.SaveChangesAsync();

            return existingEntity;
        }

        public async Task<T?> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return entity;
        }
    }
}
