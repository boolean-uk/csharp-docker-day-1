using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<Student> CreateStudent(Student entity)
        {
            await _db.Students.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var removed = await GetStudentById(id);
            if (removed != null)
            {
                _db.Students.Remove(removed);
                await _db.SaveChangesAsync();
                return removed;
            }
            else
            {
                return null;
            }
        }

        public async Task<Student> EditStudent(Student entity)
        {
            _db.Students.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(x => x.StudentId == id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }
    }
}
