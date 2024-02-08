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

        public async Task<Course> CreateCourse(string title, DateTime startDate)
        {
            Course course = new Course()
            {
                Title = title,
                StartDate = startDate,
            };
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();

            return course;
        }

        public async Task<Student> CreateStudent(string firstname, string lastname, DateTime dateOfBirth, int avgGrade)
        {
            Student student = new Student()
            {
                FirstName = firstname,
                LastName = lastname,
                DateOfBirth = dateOfBirth,
                AvgGrade = avgGrade
            };
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> DeleteCourse(int id)
        {
            Course course = await GetCourseById(id);
            if (course == null)
            {
                return null;
            }
            _db.Remove(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            Student student = await GetStudentById(id);
            if (student == null)
            {
                return null;
            }
            _db.Remove(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _db.Courses
                .Where(c => c.Id == id)
                .Include(c => c.CourseStudent)
                .ThenInclude(cs => cs.Student)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses
                    .Include(c => c.CourseStudent)
                    .ThenInclude(cs => cs.Student)
                    .ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _db.Students
                    .Where(s => s.Id == id)
                    .Include(s => s.CourseStudent)
                    .ThenInclude(cs => cs.Course)
                    .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students
                        .Include(s => s.CourseStudent)
                        .ThenInclude(cs => cs.Course)
                        .ToListAsync();
        }

        public async Task<Course> UpdateCourse(int id, string title, DateTime startDate)
        {
            Course course = await GetCourseById(id);
            if (course == null)
            {
                return null;
            }
            course.Title = title;
            course.StartDate = startDate;
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> UpdateStudent(int id, string firstname, string lastname, DateTime dateOfBirth, int avgGrade)
        {
            Student student = await GetStudentById(id);
            if (student == null)
            {
                return null;
            }
            student.FirstName = firstname;
            student.LastName = lastname;
            student.DateOfBirth = dateOfBirth;
            student.AvgGrade = avgGrade;
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Student> EnrollStudent(int studentid, int courseid)
        {
            Course course = await GetCourseById(courseid);
            Student student = await GetStudentById(studentid);
            if (student == null || course == null)
            {
                return null;
            }
            CourseStudent cs = new CourseStudent()
            {
                CourseId = course.Id,
                StudentId = student.Id
            };
            _db.CourseStudent.Add(cs);
            await _db.SaveChangesAsync();
            return student;
        }
    }
}
