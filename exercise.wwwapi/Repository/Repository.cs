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

        public async Task<Student> CreateStudent(string firstName, string lastName, string dateOfBirth, string courseTitle, string startDate, float averageGrade)
        {
            Student student = new Student();
            student.FirstName = firstName;
            student.LastName = lastName;
            student.DateOfBirth = dateOfBirth;
            student.CourseTitle = courseTitle;
            student.StartDate = startDate;
            student.AverageGrade = averageGrade;
            await _db.Students.AddAsync(student);
            _db.SaveChanges();
            return student;
        }

        public Student DeleteStudent(Student student)
        {
            _db.Students.Remove(student);
            _db.SaveChanges();
            return student;

        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Student?> GetStudentByID(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student, string? firstName, string? lastName, string? dateOfBirth, string? courseTitle, string? startDate, float? averageGrade)
        {
            if (firstName is not null) student.FirstName = firstName;
            if (lastName is not null) student.LastName = lastName;
            if (dateOfBirth is not null) student.DateOfBirth = dateOfBirth;
            if (courseTitle is not null) student.CourseTitle = courseTitle;
            if (startDate is not null) student.StartDate = startDate;
            if (averageGrade is not null) student.AverageGrade = (float)averageGrade;
            await _db.SaveChangesAsync();
            return student;
        }
    }
}
