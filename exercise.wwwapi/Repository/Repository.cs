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

        // --- Student ---
        public async Task<Student> AddStudent(Student entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return await _db.Students
                .Include(x => x.Course)
                .FirstOrDefaultAsync(x => x.Id == entity.Id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public Task<Student> GetStudent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(int id, Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<Student> DeleteStudent(Student entity)
        {
            throw new NotImplementedException();
        }

        // --- Course ---
        public Task<Course> AddCourse(Course entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public Task<Course> GetCourse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Course> UpdateCourse(int id, Course entity)
        {
            throw new NotImplementedException();
        }

        public Task<Course> DeleteCourse(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
