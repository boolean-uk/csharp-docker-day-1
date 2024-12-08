using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        public async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var target = await _dbSet.FindAsync(id);
            _dbSet.Remove(target);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            //Problem including all students with Query so had to add a specific check for type Course!!
            if (typeof(T) == typeof(Course))
            {
                var courses = await _db.Courses.Include(c => c.Students).ToListAsync();
                // Cast the result to IEnumerable<T> since we know T is Course
                return courses.Cast<T>();
            }

            
            IQueryable<T> query = _dbSet.AsQueryable();

            foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    // Skip including the main type itself
                    if (property.PropertyType != typeof(T))
                    {
                        query = query.Include(property.Name);
                    }
                }
            }

            return await query.ToListAsync();
        }



        public async Task<T> GetById(int id)
        {
            
            //Problem including all students with Query so had to add a specific check for type Course!!
            if (typeof(T) == typeof(Course))
            {
                var course = await _db.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == id);
                // Cast the result to IEnumerable<T> since we know T is Course
                return course as T;
            }
            

            IQueryable<T> query = _dbSet.AsQueryable();

            foreach (var property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    // Skip including the main type itself
                    if (property.PropertyType != typeof(T))
                    {
                        query = query.Include(property.Name);

                        // Handle ThenInclude for nested properties
                        foreach (var nestedProperty in property.PropertyType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                        {
                            if (nestedProperty.PropertyType.IsClass && nestedProperty.PropertyType != typeof(string) && nestedProperty.PropertyType != typeof(T))
                            {
                                query = query.Include($"{property.Name}.{nestedProperty.Name}");
                            }
                        }
                    }
                }
            }
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }
        
        public async Task<T> Update(T newValues)
        {
            _dbSet.Attach(newValues);
            _db.Entry(newValues).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return newValues;
        }
    }
}
