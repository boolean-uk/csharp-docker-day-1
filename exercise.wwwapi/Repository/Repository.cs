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

        public async Task<Student?> DeleteStudentById(int id)
        {
            Student? student = await  GetStudentById(id);
            if (student == null) { return null; }
             _db.Students.Remove(student);
            _db.SaveChanges();
            return student;
        }



        public async Task<Student?> GetStudentById(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(s => s.Id == id);

        }

        public async Task<List<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student?> UpdateStudentById(int id, Student StudentUpdateData)
        {
            Student? student = await GetStudentById(id);
            if (student == null) { return null; }
            student.FirstName = StudentUpdateData.FirstName;
            student.LastName = StudentUpdateData.LastName;
            student.DateOfBirth = StudentUpdateData.DateOfBirth;
            student.CourseName = StudentUpdateData.CourseName;
            student.StartDateOfCourse = StudentUpdateData.StartDateOfCourse;
            student.AvarageGrade = StudentUpdateData.AvarageGrade;
            _db.SaveChanges();
            return student;



        }
        
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Student> CreateStudent(Student Student)
        {
            await _db.Students.AddAsync(Student);
            _db.SaveChanges();
            return  Student;
        }
    }
}
