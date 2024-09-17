using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        private DbSet<Student> _students;
        private DbSet<Course> _courses;
        public Repository(DataContext db)
        {
            _db = db;
            _students = db.Students;
            _courses = db.Courses; 
        }

        public async Task<Course> AddCourse(Course course)
        {
                if (course == null)
                {
                    throw new ArgumentNullException(nameof(course));
                }

             _db.Courses.Add(course);
            _db.SaveChanges();
            return course;
            }

        public async Task<Student> AddStudent(Student student)
        {
            if (student == null)
            {
                   throw new ArgumentNullException(nameof(student));
            }
            {
                _db.Students.Add(student);
                _db.SaveChanges();  
                return student;
            }   
        }

        public async Task<Course> DeleteCourse(int id)
        {
            if (id == null)
            {
              throw new ArgumentNullException(nameof(id));
            }

            var course = await _courses.Include(a=>a.student).FirstOrDefaultAsync(c => c.Id == id);
            _courses.Remove(course);
            _db.SaveChanges();
            return course;
            }

        public async Task<Student> DeleteStudent(int id)
        {
            if(id== null)
            {
            throw new ArgumentNullException(nameof(id));
                }
            var student = await _students.Include(a => a.course).FirstOrDefaultAsync(s => s.Id == id);  

        _students.Remove(student);
            return student;
        }

        public async Task<Course> GetCourse(int id)
        {
            if(id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var course = await _courses.FirstOrDefaultAsync(c => c.Id == id);
            return course;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
                return await _db.Courses.Include(a => a.student).ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _students.Include(a => a.course).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(a=>a.course).ToListAsync();
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            if (course == null)
            {
            throw new ArgumentNullException(nameof(Student));
            }

             _courses.Entry(course).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return course;

        
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(Student));
            }
            _students.Entry(student).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return student;
        }
    }
}
