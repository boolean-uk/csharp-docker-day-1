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
            return await _db.Students.ToListAsync();
        }
        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
            }
            return student;
        }
       
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Student> CreateStudent(StudentPost studentPost)
        {
            var student = new Student
            {
                First_Name = studentPost.First_Name,
                Last_Name = studentPost.Last_Name,
                Date_Of_Birth = studentPost.Date_Of_Birth,
                CourseId = studentPost.CourseId,
                Average_Grade = studentPost.Average_Grade
            };

            _db.Students.Add(student);
            await _db.SaveChangesAsync();

            return student;
        }

        public async Task<Student> UpdateStudent(int id, Student updatedStudent)
        {
            var existingStudent = await _db.Students.FindAsync(id);

            if (existingStudent == null)
            {
            
                return null; 
            }

            _db.Entry(existingStudent).CurrentValues.SetValues(updatedStudent);
            await _db.SaveChangesAsync();

            return existingStudent;
        }
        public async Task<Course> DeleteCourse(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            if (course != null)
            {
                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();
            }
            return course;
        }

        public async Task<Course> UpdateCourse(int id, Course updatedCourse)
        {
            var existingCourse = await _db.Courses.FindAsync(id);

            if (existingCourse == null)
            {
                return null;
            }

            _db.Entry(existingCourse).CurrentValues.SetValues(updatedCourse);
            await _db.SaveChangesAsync();

            return existingCourse;
        }

        public async Task<Course> CreateCourse(Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();

            return course;
        }
    }
}

