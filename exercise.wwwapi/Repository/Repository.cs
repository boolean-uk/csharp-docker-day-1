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
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course> GetCourse(int id)
        {
            return await _db.Courses.FindAsync(id);
        }

        public async Task<Course> AddCourse(Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            _db.Entry(course).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Course> DeleteCourse(Course course)
        {
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(s => s.Course).ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> AddStudent(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _db.Entry(student).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(Student student)
        {
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return student;
        }
    }
}
