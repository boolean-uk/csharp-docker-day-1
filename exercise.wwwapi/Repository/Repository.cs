using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }

        //Student

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }
         
        public async Task<Student> GetStudentById(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
           
        }

        public async Task<Student> UpdateStudent(Student student, int id)
        {
            _db.Students.Attach(student);
            _db.Entry(student).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var studentToDelete = await _db.Students.FindAsync(id);
            if (studentToDelete != null)
            {
                _db.Students.Remove(studentToDelete);
                await _db.SaveChangesAsync();
            }
            return studentToDelete;
        }

        //Course
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _db.Courses.FindAsync(id);
        }

        public async Task AddCourse(Course course)
        {
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateCourse(Course course)
        {
            _db.Entry(course).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCourse(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            if (course != null)
            {
                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();
            }
        }
    }

}
