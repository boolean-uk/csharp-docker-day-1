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
        public async Task<Course> GetCourse(int id)
        {
            return await _db.Courses.FindAsync(id);
        }
        public async Task<Course> CreateCourse(CreateCoursePayload payload)
        {
            var course = new Course
            {
                Title = payload.Title,
                StartDate = payload.StartDate
            };
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }


        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }
        public async Task<Course> UpdateCourse(int id, UpdateCoursePayload payload)
        {
            var course = await _db.Courses.FindAsync(id);
            course.Title = payload.Title;
            course.StartDate = payload.StartDate;
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task DeleteCourse(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
        }

        

        public async Task<Student> GetStudent(int id)
        {
            return await _db.Students.FindAsync(id);
        }

        public async Task<Student> CreateStudent(CreateStudentPayload payload)
        {
            var student = new Student
            {
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                DateOfBirth = payload.DateOfBirth,
                AvrageGrade = payload.AvrageGrade
            };
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> UpdateStudent(int id, UpdateStudentPayload payload)
        {
            var student = await _db.Students.FindAsync(id);
            student.FirstName = payload.FirstName;
            student.LastName = payload.LastName;
            student.DateOfBirth = payload.DateOfBirth;
            student.AvrageGrade = payload.AvrageGrade;
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _db.Students.FindAsync(id);
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
        }

        public async Task<Student> AddStudentToCourse(CreateOrUpdateStudentCoursePayload payload)
        {
            var student = await _db.Students.FindAsync(payload.StudentId);
            student.CourseId = payload.CourseId;
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<IEnumerable<Student>> GetStudentsByCourse(int courseId)
        {
           
            return await _db.Students.Where(s => s.CourseId == courseId).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByStudent(int studentId)
        {        
            return await _db.Courses.Where(c => c.Students.Any(s => s.Id == studentId)).ToListAsync();
        }
    }
}
