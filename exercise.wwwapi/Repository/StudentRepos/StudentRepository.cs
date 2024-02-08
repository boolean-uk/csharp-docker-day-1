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
            return await _db.Students.Include(s => s.Course).ToListAsync();
        }

        public async Task<Student> AddStudent(string firstName, string lastName, DateTime birthDate, float averageGrade)
        {
            var newStudent = await _db.Students.AddAsync(
                new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Birthdate = birthDate,
                    AverageGrade = averageGrade
                });

            await _db.SaveChangesAsync();
            return newStudent.Entity;
        }

        public async Task<Student?> UpdateStudent(int id, string? firstName = null, string? lastName = null, DateTime? birthdate = null, float averageGrade = float.NaN)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id.Equals(id));
            if (student == null) { return null; }

            if (!string.IsNullOrWhiteSpace(firstName)) { student.FirstName = firstName; }
            if (!string.IsNullOrWhiteSpace(lastName)) { student.LastName = lastName; }
            if (birthdate.HasValue) { student.Birthdate = birthdate.Value; }
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

        public async Task<Student?> ApplyToCourse(int studentId, int courseId)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id.Equals(studentId));
            var course = await _db.Courses.FirstOrDefaultAsync(c => c.Id.Equals(courseId));
            if (student == null) { throw new KeyNotFoundException("The student was not found"); }
            if (course == null) { throw new KeyNotFoundException("The course was not found"); }

            if (student.CourseId != null) { throw new InvalidOperationException("The student is already enrolled in a course"); }
            if (course.AvailableSpots <= 0) { throw new InvalidOperationException("The course is full"); }

            student.CourseId = courseId;
            course.AvailableSpots--;

            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> LeaveCourse(int studentId)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Id.Equals(studentId));
            if (student == null) { throw new KeyNotFoundException("The student was not found"); }

            var course = await _db.Courses.FirstAsync(c => c.Id.Equals(student.CourseId));

            student.CourseId = null;
            course.AvailableSpots++;

            await _db.SaveChangesAsync();
            return student;
        }
    }
}
