using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private DataContext _db;
        public StudentRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }
        public async Task<Student> GetStudentById(int id)
        {
            return await _db.Students.Include(c => c.Course).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(c => c.Course).ToListAsync();
        }
        public async Task<Student> CreateStudent(Student entity)
        {
            await _db.Students.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Student> UpdateStudent(Student entity)
        {
            var updatedstudent = await _db.Students.Include(c => c.Course).FirstOrDefaultAsync(x => x.Id == entity.Id);

            updatedstudent.FirstName = entity.FirstName;
            updatedstudent.LastName = entity.LastName;
            updatedstudent.DateOfBirth = entity.DateOfBirth;
            updatedstudent.CourseId = entity.CourseId;

            await _db.SaveChangesAsync();

            return entity;
        }
        public async Task<Student> DeleteStudent(int id)
        {
            var deletedstudent = await _db.Students.Include(c => c.Course).FirstOrDefaultAsync(x => x.Id == id);

            _db.Students.Remove(deletedstudent);
            await _db.SaveChangesAsync();
            return deletedstudent;
        }

        public Task<Student> DeleteStudent(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
