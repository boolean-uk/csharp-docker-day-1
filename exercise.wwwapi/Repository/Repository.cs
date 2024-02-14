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

        public async Task<Course> AddCourse(Course course)
        {
            await _db.AddAsync(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> AddStudent(Student student)
        {
            await _db.AddAsync(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> DeleteCourse(int id)
        {
            Course course = await GetCourseById(id);
            _db.Remove(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            Student student = await GetStudentById(id);
            _db.Remove(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _db.Courses.Include(c => c.Students).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.Include(c => c.Students).ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _db.Students.Include(s => s.Courses).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(s => s.Courses).ToListAsync();
        }

        public async Task<Course> UpdateCourse(Course course, int id)
        {
            Course dbCourse = await GetCourseById(id);
            dbCourse = course;
            await _db.SaveChangesAsync();
            return await GetCourseById(id);
        }

        public async Task<Student> UpdateStudent(Student student, int id)
        {
            Student dbStudent = await GetStudentById(id);
            dbStudent = student;
            await _db.SaveChangesAsync();
            return await GetStudentById(id);
        }
    }
}
