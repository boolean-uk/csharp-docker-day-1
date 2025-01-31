using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private readonly DataContext _db;

        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.Include(c => c.StudentCourses).ThenInclude(sc => sc.Student).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(s => s.StudentCourses).ThenInclude(sc => sc.Course).ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _db.Students.Include(s => s.StudentCourses).ThenInclude(sc => sc.Course).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _db.Courses.Include(c => c.StudentCourses).ThenInclude(sc => sc.Student).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Student> AddStudent(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> AddCourse(Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task AddStudentToCourse(int studentId, int courseId)
        {
            var studentCourse = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };
            _db.StudentCourses.Add(studentCourse);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveStudentFromCourse(int studentId, int courseId)
        {
            var studentCourse = await _db.StudentCourses.FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
            if (studentCourse != null)
            {
                _db.StudentCourses.Remove(studentCourse);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            var existingStudent = await _db.Students.FindAsync(id);
            if (student != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.StudentNumber = student.StudentNumber;
                await _db.SaveChangesAsync();
            }
            return student;
        }

        public async Task<Course> UpdateCourse(int id, Course course)
        {
            var existingCourse = await _db.Courses.FindAsync(id);
            if (course != null)
            {
                existingCourse.Title = course.Title;
                existingCourse.Description = course.Description;
                await _db.SaveChangesAsync();
            }
            return course;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> DeleteCourse(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            if (course != null)
            {
                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();
            }
            return true;
        }
    }
}
