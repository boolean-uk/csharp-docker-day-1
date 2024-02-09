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

        public async Task<Course> CreateCourse(string courseTitle, string startDate)
        {
            Course course = new Course();
            course.CourseTitle = courseTitle;
            course.StartDate = startDate;
            await _db.Courses.AddAsync(course);
            _db.SaveChanges();
            return course;
        }

        public async Task<Student> CreateStudent(string firstName, string lastName, string dateOfBirth)
        {
            Student student = new Student();
            student.FirstName = firstName;
            student.LastName = lastName;
            student.DateOfBirth = dateOfBirth;
            await _db.Students.AddAsync(student);
            _db.SaveChanges();
            return student;
        }

        public Course DeleteCourse(Course course)
        {
            _db.Courses.Remove(course);
            var registrations = _db.Registrations.Where(x => x.CourseId == course.Id);
            foreach (var registration in registrations)
            {
                _db.Registrations.Remove(registration);
            }
            _db.SaveChanges();
            return course;
        }

        public Student DeleteStudent(Student student)
        {
            _db.Students.Remove(student);
            _db.SaveChanges();
            return student;

        }

        public async Task<Course?> GetCourseByID(int id)
        {
            return await _db.Courses.Include(x=> x.Registrations).ThenInclude(x => x.Student).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.Include(x => x.Registrations).ThenInclude(x => x.Student).ToListAsync();
        }

        public async Task<Student?> GetStudentByID(int id)
        {
            return await _db.Students.Include(x => x.Registrations).ThenInclude(x => x.Course).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(x => x.Registrations).ThenInclude(x => x.Course).ToListAsync();
        }

        public async Task<Course> UpdateCourse(Course course, string? courseTitle, string? startDate)
        {
            if (courseTitle is not null) course.CourseTitle= courseTitle;
            if (startDate is not null) course.StartDate = startDate;
            
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> UpdateStudent(Student student, string? firstName, string? lastName, string? dateOfBirth)
        {
            if (firstName is not null) student.FirstName = firstName;
            if (lastName is not null) student.LastName = lastName;
            if (dateOfBirth is not null) student.DateOfBirth = dateOfBirth;
            await _db.SaveChangesAsync();
            return student;
        }
    }
}
