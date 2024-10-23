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
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }
        public async Task<Student> GetStudent(int id)
        {
            Student student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);

            return student;
        }
        public async Task<Course> GetCourse(int id)
        {
            Course course = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);

            return course;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            Student student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student != null)
            {
                _db.Remove(student);
                await _db.SaveChangesAsync();
            }
            return student;
        }

        public async Task<Course> DeleteCourse(int id)
        {
            Course course = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);

            if (course != null)
            {
                _db.Remove(course);
                await _db.SaveChangesAsync();
            }
            return course;
        }

        public async Task<Student> CreateStudent(StudentDTO student)
        {
            Student newStudent = new Student();
            newStudent.Id = student.Id; 
            newStudent.firstName = student.firstName; 
            newStudent.lastName = student.lastName;
            newStudent.dateOfBirth = student.dateOfBirth;
            newStudent.courseId = student.courseId;

            await _db.AddAsync(newStudent);
            await _db.SaveChangesAsync();

            return newStudent;
        }

        public async Task<Course> CreateCourse(CourseDTO course)
        {
            Course newCourse = new Course();
            newCourse.Id = course.Id;
            newCourse.Title = course.Title;
            newCourse.AverageGrade = course.AverageGrade;
            newCourse.StartDate = DateTime.UtcNow;

            await _db.AddAsync(newCourse);
            await _db.SaveChangesAsync();

            return newCourse;
        }
    }
}
