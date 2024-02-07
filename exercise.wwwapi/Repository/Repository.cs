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

        public async Task<Student?> GetAStudent(int id)
        {
            return await _db.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student?> CreateStudent(string FirstName, string LastName, DateOnly DateOfBirth)
        {
            if (FirstName == "" || LastName == "" || DateOfBirth == null) return null;
            var student = new Student { FirstName = FirstName, LastName = LastName, DateOfBirth = DateOfBirth };
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            return student;
        }

     
    

    public async Task<Student?> UpdateStudent(int id, string newFirstName, string newLastName, DateOnly DateOfBirth)
        {
            Student student = await GetAStudent(id);
            if (student != null)
            {
                student.FirstName = newFirstName ?? student.FirstName;
                student.LastName = newLastName ?? student.LastName;
                student.DateOfBirth = DateOfBirth != null ? DateOfBirth : student.DateOfBirth;

                await _db.SaveChangesAsync();

                return student;
            }
            return null;
        }

        public async Task<Student?> DeleteStudent(int id)
        {
            Student student = await GetAStudent(id);

            if (student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();

                return student;
            }

            return null;
        }

       


        

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }
        /*
        public async Task<Course?> GetACourse(int id)
        {
            return await _db.Courses.Include(c => c.Enrollments).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course?> CreateCourse(string CourseTitle, DateOnly startDate)
        {
            if (CourseTitle == ""|| startDate == null) return null;
            var course = new Course { CourseTitle = CourseTitle, StartDate = startDate };
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
            return course;
        }


        public async Task<Course?> UpdateCourse(int id, string newTitle, DateOnly newStartDate)
        {
            Course course = await GetACourse(id);
            if (course != null)
            {
                course.CourseTitle = newTitle ?? course.CourseTitle;
                course.StartDate = newStartDate != null ? newStartDate : course.StartDate;
       
                await _db.SaveChangesAsync();

                return course;
            }
            return null;
        }

        public async Task<Course?> DeleteCourse(int id)
        {
            Course course = await GetACourse(id);

            if (course != null)
            {
                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();

                return course;
            }

            return null;
        }*/
    }
}
