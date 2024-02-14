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

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(x=>x.Course).ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _db.Students.Include(x => x.Course).FirstAsync(x => x.Id == id);
        }
        public async Task<Student> CreateStudent(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChangesAsync();
            return student;
        }
        public async Task<Student> UpdateStudent(int id, Student student)
        {
            var updatedStudent = await GetStudent(id);
            updatedStudent.FirstName = student.FirstName;
            updatedStudent.LastName = student.LastName;
            updatedStudent.DateOfBirth = student.DateOfBirth;
            updatedStudent.CourseId = student.CourseId;

            _db.SaveChangesAsync();
            return updatedStudent;
        }
        public async Task<Student> DeleteStudent(int id)
        {
            var student = await GetStudent(id);

            _db.Students.Remove(student);
            _db.SaveChangesAsync();
            return student;
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.Include(x => x.Students).ToListAsync();
        }

        public async Task<Course> GetCourse(int id)
        {
            return await _db.Courses.Include(x => x.Students).FirstAsync(x => x.Id == id);
        }
        public async Task<Course> DeleteCourse(int id)
        {
            var course = await GetCourse(id);
            _db.Remove(course);
            _db.SaveChangesAsync();
            return course;
        }
        public async Task<Course> UpdateCourse(int id, Course course)
        {
            var updatedCourse = await GetCourse(id);

            updatedCourse.CourseTitle = course.CourseTitle;
            updatedCourse.CourseStartDate = course.CourseStartDate;
            updatedCourse.AverageGrade = course.AverageGrade;
            updatedCourse.Students = course.Students;

            _db.SaveChangesAsync();
            return updatedCourse;
        }

        public async Task<Course> CreateCourse(Course course)
        {
            _db.Add(course);
            _db.SaveChangesAsync();
            return course;
        }
    }
}
