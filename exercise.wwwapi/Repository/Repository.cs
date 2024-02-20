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

        // Core
        public async Task<Student> Create(StudentPost student)
        {
            var nextId = _db.Students.Count();

            Student create = new Student()
            {
                Id = nextId + 1,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                CourseId = student.CourseId,
                Course = _db.Courses.First(c => c.Id == student.CourseId)
            };

            _db.Students.Add(create);
            _db.SaveChanges();
            return create;
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Student> Update(StudentPut student, int id)
        {
            var update = _db.Students.Single(s => s.Id == id);
            if (update == null)
            {

            }
            _db.Students.Attach(update);
            
            update.FirstName = !string.IsNullOrEmpty(student.FirstName) ? student.FirstName : update.FirstName;

            update.LastName = !string.IsNullOrEmpty(student.LastName) ? student.LastName : update.LastName;

            if (!student.DateOfBirth.HasValue)
            {
                update.DateOfBirth = student.DateOfBirth.Value;
            }
            if (!student.CourseId.HasValue)
            {
                update.CourseId = student.CourseId.Value;
            }
            
            _db.SaveChanges();
            return update;

        }
        public async Task<Student> Delete(int id)
        {
            var delete = _db.Students.Single(s => s.Id == id);
            _db.Students.Remove(delete);
            _db.SaveChanges();
            return delete;
        }

        // Extension
        public async Task<Course> CreateCourse(CoursePost course)
        {
            var nextId = _db.Courses.Count();
            Course create = new Course()
            {
                Id = nextId + 1,
                Title = course.Title,
                CourseStart = course.CourseStart,
                AverageGrade = course.AverageGrade
            };

            _db.Courses.Add(create);
            _db.SaveChanges();
            return create;
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }
        public async Task<Course> UpdateCourse(CoursePut course, int id)
        {
            var update = _db.Courses.Single(c => c.Id == id);
            if (update == null)
            {

            }
            _db.Courses.Attach(update);

            update.Title = !string.IsNullOrEmpty(course.Title) ? course.Title : update.Title;
            
            if (!course.CourseStart.HasValue)
            {
                update.CourseStart = course.CourseStart.Value;
            }
            if (!course.AverageGrade.HasValue)
            {
                update.AverageGrade = course.AverageGrade.Value;
            }
            _db.SaveChanges();
            return update;
        }
        public async Task<Course> DeleteCourse(int id)
        {
            var delete = _db.Courses.Single(c => c.Id == id);
            _db.Courses.Remove(delete);
            _db.SaveChanges();
            return delete;
        }




    }
}
