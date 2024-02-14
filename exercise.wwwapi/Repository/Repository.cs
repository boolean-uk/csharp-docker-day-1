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
            var students = from student in _db.Students
                           select new Student()
                           {
                               Id = student.Id,
                               FirstName = student.FirstName,
                               LastName = student.LastName,
                               DateOfBirth = student.DateOfBirth,
                               CourseTitle = student.CourseTitle,
                               StartDate = student.StartDate,
                               Grade = student.Grade,
                           };
            return await students.ToListAsync();
        }
         
        public async Task<Student> GetStudentById(int id)
        {
            var student = await _db.Students.Select(student => new Student()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                CourseTitle = student.CourseTitle,
                StartDate = student.StartDate,
                Grade = student.Grade,
            }).SingleOrDefaultAsync(p => p.Id == id);
            return student;
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

            Student deleting = new Student()
            {
                Id = studentToDelete.Id,
                FirstName = studentToDelete.FirstName,
                LastName = studentToDelete.LastName,
                DateOfBirth = studentToDelete.DateOfBirth,
                CourseTitle = studentToDelete.CourseTitle,
                StartDate = studentToDelete.StartDate,
                Grade = studentToDelete.Grade,
            };
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
