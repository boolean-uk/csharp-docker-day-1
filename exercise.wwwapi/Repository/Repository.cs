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
            return await _db.Courses.Include(c => c.Students).ToListAsync();
        }
        public async Task<Course> GetCourseById(int id)
        {
            return await _db.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Course> AddCourse(Course course)
        {
            await _db.AddAsync(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(s => s.course).ToListAsync();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await _db.Students.Include(s => s.course).FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Student> AddStudent(Student student)
        {
            await _db.AddAsync(student);
            await _db.SaveChangesAsync();
            return student;
        }
        public async Task<Student> UpdateStudent(Student student)
        {
            _db.Attach(student).State = EntityState.Modified;
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
