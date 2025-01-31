using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;
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

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Course> GetCourse(int id)
        {
            return await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Course> AddCourse(CourseDTO courseDTO)
        {
            Course course = new Course()
            {
                Name = courseDTO.Name,
                Description = courseDTO.Description,
                Students = new List<Student>()
            };

            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> AddStudent(StudentDTO studentDTO)
        {
            Student student = new Student()
            {
                Name = studentDTO.Name,
                Email = studentDTO.Email,
                PhoneNumber = studentDTO.PhoneNumber,

            };


            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Student> AddStudentToCourse(int studentId, int courseId)
        {
            var student = await _db.Students.Include(s => s.Courses)
                                            .FirstOrDefaultAsync(s => s.Id == studentId);
            var course = await _db.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

            if (student == null || course == null)
            {
                return null; 
            }

            if (!student.Courses.Contains(course))
            {
                student.Courses.Add(course);
                await _db.SaveChangesAsync();
            }
            return student;

        }


        public async Task<Course> UpdateCourse(Course course)
        {
            _db.Courses.Update(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Course> DeleteCourse(int id)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(x => x.Id == id);
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return student;
        }
    }
}
