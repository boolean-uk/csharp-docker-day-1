using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private DataContext _db;
        public StudentRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student> AddStudent(string firstName, string lastName, DateTime birthDate, string courseTitle, DateTime courseStartDate, float averageGrade)
        {
            var newStudent = await _db.Students.AddAsync(
                new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Birthdate = birthDate,
                    CourseTitle = courseTitle,
                    CourseStartDate = courseStartDate,
                    AverageGrade = averageGrade
                });

            await _db.SaveChangesAsync();
            return newStudent.Entity;
        }

        public async Task<Student?> UpdateStudent(int id, string? firstName = null, string? lastName = null, DateTime? birthdate = null, string? courseTitle = null, DateTime? courseStartDate = null, float averageGrade = float.NaN)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id.Equals(id));
            if (student == null) { return null; }

            if (!string.IsNullOrWhiteSpace(firstName)) { student.FirstName = firstName; }
            if (!string.IsNullOrWhiteSpace(lastName)) { student.LastName = lastName; }
            if (birthdate.HasValue) { student.Birthdate = birthdate.Value; }
            if (!string.IsNullOrWhiteSpace(courseTitle)) { student.CourseTitle = courseTitle; }
            if (courseStartDate.HasValue) { student.CourseStartDate = courseStartDate.Value; }
            if (!float.IsNaN(averageGrade)) { student.AverageGrade = averageGrade; }


            await _db.SaveChangesAsync();

            return student;
        }

        public async Task<Student?> DeleteStudent(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id.Equals(id));
            if (student == null) { return null; }

            _db.Students.Remove(student);

            await _db.SaveChangesAsync();
            return student;
        }
    }
}
