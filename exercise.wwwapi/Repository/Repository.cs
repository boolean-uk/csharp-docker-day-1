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
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> AddStudent(Student student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> DeleteCourse(int id)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(c => c.Id == id);
            _db.Courses.Remove(course);
            _db.SaveChangesAsync();

            return course;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id == id); 
            _db.Students.Remove(student);
            _db.SaveChangesAsync();

            return student;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }
        /*
        public async Task<Course> GetCourseById(int id)
        {
            return await _db.Courses.FirstOrDefaultAsync(c => c.Id  == id);
        }
        */

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await _db.Students.Include(s => s.Course).ToListAsync();

            return students;
        }

        public Task<Course> UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _db.Attach(student).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return student;
        }
    }
}
