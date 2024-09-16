using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository(DataContext db) : IRepository
    {
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await db.Courses.ToListAsync();
        }
        
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await db.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return (await db.Students.FirstOrDefaultAsync(x => x.Id == id))!;
        }

        public async Task<Course> GetCourseById(int id)
        {
            return (await db.Courses.FirstOrDefaultAsync(x => x.Id == id))!;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var s = await GetStudentById(student.Id);
            s.BirthDate = student.BirthDate;
            s.FirstName = student.FirstName;
            s.LastName = student.LastName;
            await db.SaveChangesAsync();
            return s;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            var c = await GetCourseById(course.Id);
            c.Title = course.Title;
            c.StartDate = course.StartDate;
            c.AverageGrade = course.AverageGrade;
            await db.SaveChangesAsync();
            return c;
        }

        public async Task<Student> AddStudent(Student student)
        {
            await db.Students.AddAsync(student);
            await db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> AddCourse(Course course)
        {
            await db.Courses.AddAsync(course);
            await db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> DeleteStudent(Student student)
        {
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> DeleteCourse(Course course)
        {
            db.Courses.Remove(course);
            await db.SaveChangesAsync();
            return course;
        }
    }
}
