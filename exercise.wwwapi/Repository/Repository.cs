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

        public Task<Course> CreateCourse(PostCourse course)
        {
            throw new NotImplementedException();
        }

        public Task<Student> CreateStudent(PostStudent student)
        {
            throw new NotImplementedException();
        }

        public Task<Course> DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourse(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public Task<Student> GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public Task<Course> UpdateCourse(int id, PutCourse course)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(int id, PutStudent student)
        {
            throw new NotImplementedException();
        }
    }
}
