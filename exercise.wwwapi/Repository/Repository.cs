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
        public async Task<Student?> GetStudent(int id)
        {
            if (id < 0)
            {
                return null;
            }
            return await _db.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(s => s.Enrollments).ThenInclude(e => e.Course).ToListAsync();
        }
        public async Task<Student?> UpdateStudent(int id, string FirstName, string LastName, string Dob, int CourseId, int AvgGrade)
        {
            //Get student to be updated
            var student = await GetStudent(id);
            //Add update data to student
            student.FirstName = FirstName;
            student.LastName = LastName;
            student.DoB = Dob;
            student.AvgGrade = AvgGrade;
            //Return student with new data and save changes
            _db.SaveChanges();
            return student;
        }
        public async Task<Student> CreateStudent(string FirstName, string LastName, string Dob, int CourseId, int AvgGrade)
        {
            Student student = new Student();
            student.FirstName = FirstName;
            student.LastName = LastName;
            student.DoB = Dob;
            student.AvgGrade= AvgGrade;
            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }
        public async Task<Student?> DeleteStudent(int id)
        {
            var student = await GetStudent(id);
            _db.Students.Remove(student);
            _db.SaveChanges(); 
            return student;
        }


        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.Include(s => s.Students).ThenInclude(s => s.Student).ToListAsync();
        }

        public async Task<Course?> GetCourse(int id)
        {
            if (id < 0)
            {
                return null;
            }
            return await _db.Courses.Include(s => s.Students).ThenInclude(s => s.Student).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Course?> UpdateCourse(int id, string Title, string Description, string StartDate)
        {
            //Get course to be updated
            var course = await GetCourse(id);
            //Add update data to course
            course.Title = Title;
            course.Description = Description;
            course.StartDate = StartDate;
            //Return course with new data and save changes
            _db.SaveChanges();
            return course;
        }

        public async Task<Course> CreateCourse(string Title, string Description, string StartDate)
        {
            Course course = new Course();
            course.Title = Title;
            course.Description = Description;
            course.StartDate = StartDate;
            _db.Courses.Add(course);
            _db.SaveChanges();
            return course;
        }

        public async Task<Course?> DeleteCourse(int id)
        {
            var course = await GetCourse(id);
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return course;
        }

        public async Task<Join_student_course?> CreateEnrollment(Student Student, Course Course)
        {
            var enrollment = new Join_student_course();
            enrollment.Course = Course;
            enrollment.Student = Student;
            enrollment.CourseId = Course.Id;
            enrollment.StudentId = Student.Id;
            _db.JoinStudents.Add(enrollment);
            _db.SaveChanges();
            return enrollment;
        }
    }
}
