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

        public async Task<Course> AddCourse(Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> AddCourseOnStudent(int id, int courseId)
        {
            var student = await _db.Students.FindAsync(id);
            var course = await _db.Courses.FindAsync(courseId);

            if (student != null && course != null)
            {
                student.Courses.Add(course);
                await _db.SaveChangesAsync();
            }

            return student;
        }

        public async Task<Student> AddStudent(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> DeleteCourse(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _db.Students.FindAsync(id);
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> GetCourseById(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            return course;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            var student = await _db.Students.FindAsync(id);
            return student;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Course> UpdateCourse(int id, Course course)
        {
            var existingCourse = await GetCourseById(id);

            if (existingCourse != null)
            {
                if (existingCourse.Title != course.Title)
                {
                    existingCourse.Title = course.Title;
                }

                if (existingCourse.AverageGrade != course.AverageGrade)
                {
                    existingCourse.AverageGrade = course.AverageGrade;
                }

                await _db.SaveChangesAsync();
            }

            return existingCourse;
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            var existingStudent = await GetStudentById(id);

            if (existingStudent != null)
            {
                if (existingStudent.FirstName != student.FirstName)
                {
                    existingStudent.FirstName = student.FirstName;
                }

                if (existingStudent.LastName != student.LastName)
                {
                    existingStudent.LastName = student.LastName;
                }

                if (existingStudent.BirthDate != student.BirthDate)
                {
                    existingStudent.BirthDate = student.BirthDate;
                }

                await _db.SaveChangesAsync();
            }

            return existingStudent;
        }
    }
}
