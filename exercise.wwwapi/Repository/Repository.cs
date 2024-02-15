using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _databaseContext;
        private DbSet<T> _dbSet;
        public Repository(DataContext db)
        {
            _databaseContext = db;
            _dbSet = db.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            _dbSet.Add(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Student>> GetAllStudentsWithCourses()
        {
            return await _databaseContext.Students.Include(s => s.Courses).ToListAsync();
        }

        public async Task<Student> GetSpecificStudentWithCourses(int id)
        {
            return await _databaseContext.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == id); 
        }
    }
}
