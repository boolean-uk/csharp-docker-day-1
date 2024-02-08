using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.Endpoints;
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

        public async Task<Student> CreateStudent(Student student)
        {
            await _db.Students.AddAsync(student);
            _db.SaveChanges();
            return student;
        }

        public async Task<Student?> DeleteStudent(int studentId)
        {
            Student? student = await GetStudent(studentId);
            if(student == null) { return null; }
            _db.Students.Remove(student);
            _db.SaveChanges();
            return student;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Student?> GetStudent(int studentId)
        {
            return await _db.Students.FirstOrDefaultAsync(s => s.Id == studentId);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student?> UpdateStudent(int studentId, Student student)
        {
            Student? studentToUpdate = await GetStudent(studentId);
            if(studentToUpdate == null) { return null; }

            studentToUpdate.FirstName = student.FirstName ?? studentToUpdate.FirstName;
            studentToUpdate.LastName = student.LastName ?? studentToUpdate.LastName;
            studentToUpdate.DateOfBirth = student.DateOfBirth ?? studentToUpdate.DateOfBirth;
            studentToUpdate.CourseTitle = student.CourseTitle ?? studentToUpdate.CourseTitle;
            studentToUpdate.StartDate = student.StartDate;
            studentToUpdate.Grade = student.Grade;
            _db.SaveChanges();

            return student;        
        }
    }
}
