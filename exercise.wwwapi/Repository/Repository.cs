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
        public async Task<Course> GetCourse(int id)
        {
            return await _db.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }




        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(s => s.Course).ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> CreateStudent(Student student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            return await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == student.Id);
        }
        public async Task<Student> DeleteStudent(int id)
        {
            Student student = await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
            if (student != null)
            {
                _db.Remove(student);
                await _db.SaveChangesAsync();
            }
            return student;
        }

        public async Task<Student> UpdateStudent(Student student, int id)
        {
            Student s = await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
            if(s != null)
            {
                s.FirstName = student.FirstName;
                s.LastName = student.LastName;
                s.Birth = student.Birth;
                s.CourseId = student.CourseId;
                await _db.SaveChangesAsync();
            }
            return await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);

        }
    }
}
