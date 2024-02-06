using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<Student?> createStudent(string first_name, string last_name, DateTimeOffset d_o_b)
        {
            if (first_name == null || first_name == "")
            {
                return null;
            }
            if (last_name == null || last_name == "")
            {
                return null;
            }
            if (d_o_b == null)
            {
                return null;
            }
            var result = new Student() { FirstName = first_name, LastName = last_name, DoB = d_o_b, CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow};
            _db.Students.Add(result);
            await _db.SaveChangesAsync();

            return result;
        }

        public async Task<Student?> deleteStudent(int id)
        {
            var student = await getStudentById(id);
            if (student == null)
            {
                return null;
            }
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<IEnumerable<Student>> getStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student?> getStudentById(int id)
        {
            return await _db.Students.FindAsync(id);
        }

        public async Task<Student?> updateStudent(int id, string? first_name, string? last_name, DateTimeOffset? d_o_b)
        {
            Student? student = await getStudentById(id);
            if (student == null)
            {
                return null;
            }
            if (first_name == "")
            {
                return null;
            }
            if (last_name == "")
            {
                return null;
            }
            if (d_o_b == null)
            {
                return null;
            }

            if (first_name != null)
            {
                student.FirstName = first_name;
                student.UpdatedAt = DateTimeOffset.UtcNow;
            }
            if (last_name != null)
            {
                student.LastName = last_name;
                student.UpdatedAt = DateTimeOffset.UtcNow;
            }
            if (d_o_b != null)
            {
                student.DoB = d_o_b.Value;
                student.UpdatedAt = DateTimeOffset.UtcNow;
            }
            await _db.SaveChangesAsync();
            return student;

        }
        public async Task<IEnumerable<Course>> getCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course?> getCourseById(int id)
        {
            return await _db.Courses.FindAsync(id);
        }

        public async Task<Course?> createCourse(string course_title, DateTimeOffset course_start_date)
        {
            if (course_title == null || course_title == "")
            {
                return null;
            }
            if (course_start_date == null)
            {
                return null;
            }
            
            var result = new Course() { CourseTitle = course_title, CourseStartDate = course_start_date, CreatedAt = DateTimeOffset.UtcNow, UpdatedAt = DateTimeOffset.UtcNow };
            _db.Courses.Add(result);
            await _db.SaveChangesAsync();

            return result;
        }

        public async Task<Course?> updateCourse(string? course_title, DateTimeOffset? course_start_date)
        {
            throw new NotImplementedException();
        }

        public async Task<Course?> deleteCourse(int id)
        {
            Course? course = await getCourseById(id);
            if (course == null) {
                return null;
            }
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
            return course;
        }
    }
}
