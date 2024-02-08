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
            return await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);

        }

        public async Task<List<Student>> GetStudents()
        {
            return await _db.Students.Include(s => s.Course).ToListAsync();
        }

        public async Task<Student?> UpdateStudentById(int id, Student StudentUpdateData)
        {
            Student? student = await GetStudentById(id);
            if (student == null) { return null; }
            student.FirstName = StudentUpdateData.FirstName;
            student.LastName = StudentUpdateData.LastName;
            student.DateOfBirth = StudentUpdateData.DateOfBirth;
            student.CourseId = StudentUpdateData.CourseId;
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
