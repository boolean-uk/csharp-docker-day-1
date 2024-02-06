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
        
        /*
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }
        */

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student> CreateStudent(CreateNewStudentPayload createData)
        {
            Student student = new Student();
            student.FirstName = createData.FirstName;
            student.LastName = createData.LastName;
            student.DateOfBirth = createData.DateOfBirth;
            student.CourseTitle = createData.CourseTitle;
            student.CourseStartDate = createData.CourseStartDate;
            student.AverageGrade = createData.AverageGrade;
            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }

        public async Task<Student> UpdateStudent(int id, UpdateStudentPayload updateData)
        {
            var student = await _db.Students.FindAsync(id);
            student.FirstName = updateData.FirstName;
            student.LastName = updateData.LastName;
            student.DateOfBirth = updateData.DateOfBirth;
            student.CourseTitle = updateData.CourseTitle;
            student.CourseStartDate = updateData.CourseStartDate;
            student.AverageGrade = updateData.AverageGrade;
            _db.SaveChanges();
            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _db.Students.FindAsync(id);
            _db.Students.Remove(student);
            _db.SaveChanges();
            return student;
        }
    }
}
