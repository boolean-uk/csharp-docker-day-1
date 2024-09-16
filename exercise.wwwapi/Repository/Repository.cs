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

        public async Task<Course> CreateCourse(Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Course> DeleteCourse(Course course)
        {
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Course> GetACourse(int id)
        {
            return await _db.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            _db.Courses.Update(course);
            await _db.SaveChangesAsync();
            return course;
        }
    }
}
