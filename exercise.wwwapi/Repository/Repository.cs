using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
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
        
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(s => s.Course).ToListAsync();
        }

        public async Task<Student> CreateStudent(StudentPayload createData)
        {
            if(
                createData.FirstName == null ||
                createData.LastName == null ||
                createData.DateOfBirth == null)
            {
                return null;
            }

            Student student = new Student();
            student.FirstName = createData.FirstName;
            student.LastName = createData.LastName;
            student.DateOfBirth = createData.DateOfBirth;
            student.AverageGrade = createData.AverageGrade;
            student.CourseId = createData.courseId;
            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }

        public async Task<Student> UpdateStudent(int id, StudentPayload updateData)
        {
            var student = await _db.Students.FindAsync(id);
            if(student == null)
            {
                return null;
            }
            if (
                updateData.FirstName == null ||
                updateData.LastName == null ||
                updateData.DateOfBirth == null)
            {
                return null;
            }

            student.FirstName = updateData.FirstName;
            student.LastName = updateData.LastName;
            student.DateOfBirth = updateData.DateOfBirth;
            student.AverageGrade = updateData.AverageGrade;
            student.CourseId = updateData.courseId;
            _db.SaveChanges();
            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if(student == null)
            {
                return null;
            }
            _db.Students.Remove(student);
            _db.SaveChanges();
            return student;
        }
    }
}
