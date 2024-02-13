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
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.Include(x=>x.Students).ToListAsync();
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(x=>x.Course).ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            T entity = await _table.FindAsync(id);
            _db.SaveChanges();
            return entity;
        }
        public async Task<T> Insert(T entity)
        {
            await _table.AddAsync(entity);
            _db.SaveChanges();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            _table.Update(entity);
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            T entity = await _table.FindAsync(id);
            _table.Remove(entity);
            return entity;
        }
    }
}
