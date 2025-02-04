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

        public async Task<Course> AddCourse(string name)
        {
           
            Course course = new Course();
            course.Name = name;
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
            return course;


        }

        public async Task<Student> AddStudent(string name)
        {
            Student student = new Student();
            student.Name = name;
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async  Task<Course> DeleteCourse(int id)
        {
            var courses = await _db.Courses.FirstOrDefaultAsync(c => c.Id == id);
            _db.Courses.Remove(courses);
            await _db.SaveChangesAsync();
            return courses;
     
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var students = await _db.Students.FirstOrDefaultAsync(c => c.Id == id);
            _db.Students.Remove(students);
            await _db.SaveChangesAsync();
            return students;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Course> UpdateCourse(int id, string name)
        {
            var courses = await _db.Courses.FirstOrDefaultAsync(c => c.Id == id);
            courses.Id = id;
            courses.Name = name;
            await _db.SaveChangesAsync();
            return courses;
        }

        public async Task<Student> UpdateStudent(int id, string name)
        {
            var students = await _db.Students.FirstOrDefaultAsync(c => c.Id == id);
            students.Id = id;
            students.Name= name;
            await _db.SaveChangesAsync();
            return students;
        }
    }
}
