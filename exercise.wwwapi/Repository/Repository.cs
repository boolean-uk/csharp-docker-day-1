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
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }
        public async Task<Student> GetAStudent(int id)
        {
            return await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Student> AddStudent(Student student)
        {
            _db.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course> AddCourse(Course entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Course> GetACourse(int id)
        {
            return await _db.Courses.FindAsync(id);
        }
        public async Task<bool> DeleteCourse(int id)
        {
            var course = _db.Courses.Find(id);
            if(course != null)
            {
                _db.Remove(course);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<Course> UpdateCourse(int id, Course model)
        {
            var entity = _db.Courses.Find(id);
            _db.Attach(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
