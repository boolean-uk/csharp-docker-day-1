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

        public async Task<IEnumerable<T>> GetAll()
        {
            //for including all students
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
            //for including all students
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

                        
                    }
                }
            }
            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }
    

 

        public async Task<T> Update(int id, T newValues)
        {
            throw new NotImplementedException();
        }
    }
}
