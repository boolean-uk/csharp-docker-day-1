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
            return await _db.Students.Include(c => c.Course).ToListAsync();
        }

        public async Task<Student?> GetStudent(int id)
        {
            var task = await _db.Students.Include(c => c.Course).FirstOrDefaultAsync(t => t.Id == id);
            return task;
        }

        public async Task<Student?> AddStudent(string firstname, string lastname, string birthday, string grade, int courseId)
        {
            List<Student> students = _db.Students.ToList();
            int nrStudents = await _db.Students.CountAsync();

            int id = 0;
            if (students.Count > 0)
                id = students.Last().Id;
            id++;

            for (int i = 0; i < nrStudents; i++)
            {
                if (students[i].FirstName == firstname && students[i].LastName == lastname)
                    return null;
            }

            var newStudent = new Student() { Id = id, FirstName = firstname, LastName = lastname, Birthday = birthday, AverageGrade = grade, CourseId = courseId };
            await _db.AddAsync(newStudent);
            await _db.SaveChangesAsync();
            return newStudent;
        }

        public async Task<Student>? ChangeStudent(Student student, string? firstname, string? lastname, string? birthday, string? grade, int? courseId)
        {
            bool hasUpdate = false;
            List<Student> studentList = _db.Students.ToList();

            if (firstname != null)
            {
                student.FirstName = firstname;
                hasUpdate = true;
            }

            if (lastname != null)
            {
                student.LastName = lastname;
                hasUpdate = true;
            }

            if (birthday != null)
            {
                student.Birthday = birthday;
                hasUpdate = true;
            }

            if (grade != null)
            {
                student.AverageGrade = grade;
                hasUpdate = true;
            }

            if (!hasUpdate) throw new Exception("No update data provided");
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<IEnumerable<Student>> RemoveStudent(Student student)
        {
            _db.Students.Remove(student);
            await _db.SaveChangesAsync();
            return await _db.Students.ToListAsync();
        }




        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.Include(s => s.Students).ToListAsync();
        }

        public async Task<Course?> GetCourse(int id)
        {
            var task = await _db.Courses.Include(s => s.Students).FirstOrDefaultAsync(t => t.Id == id);
            return task;
        }

        public async Task<Course?> AddCourse(string title, DateTime startDate)
        {
            List<Course> courses = _db.Courses.ToList();
            int nrCourses = await _db.Courses.CountAsync();

            int id = 0;
            if (courses.Count > 0)
                id = courses.Last().Id;
            id++;

            for (int i = 0; i < nrCourses; i++)
            {
                if (courses[i].Title == title)
                    return null;
            }

            var newCourse = new Course() { Id = id, Title = title, StartDate = startDate };
            await _db.AddAsync(newCourse);
            await _db.SaveChangesAsync();
            return newCourse;
        }

        public async Task<Course>? ChangeCourse(Course course, string? title, DateTime? startDate)
        {
            bool hasUpdate = false;
            List<Course> coursList = _db.Courses.ToList();

            if (title != null)
            {
                course.Title = title;
                hasUpdate = true;
            }

            if (startDate != null)
            {
                course.StartDate = (DateTime)startDate;
                hasUpdate = true;
            }

            if (!hasUpdate) throw new Exception("No update data provided");
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<IEnumerable<Course>> RemoveCourse(Course course)
        {
            _db.Courses.Remove(course);
            await _db.SaveChangesAsync();
            return await _db.Courses.ToListAsync();
        }
    }
}
