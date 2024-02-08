using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
            return await _db.Students.Include(s => s.Courses).ToListAsync();
        }
        public async Task<Student?> GetStudent(int studentId)
        {
            var student = await _db.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == studentId);

            if(student.FirstName == null) //find does not work with include. and Firstordefaultasync does not return null. so im checking if one of the internal components are null to verify if the course is null.
            {
                return null;
            }

            return student;
        }


        public async Task<Student?> UpdateStudent(int studentId, string firstName, string lastName, string dateOfBirth, List<int> courseIds)
        {
            var student = await _db.Students.FindAsync(studentId);
            if (student == null)
            {
                return null;
            }

            student.Id = studentId;
            student.FirstName = firstName;
            student.LastName = lastName;
            student.DateOfBirth = dateOfBirth;
            foreach(int courseId in courseIds)
            {

                var course = await _db.Courses.FindAsync(courseId);
                if (course == null)
                {
                    return null;
                }
                student.Courses.Add(course);
            }
            
            _db.SaveChanges();
            return student;
        }
        public async Task<Student?> CreateStudent(string firstName, string lastName, string dateOfBirth, List<int> courseIds)
        {
            List<Course> temp = new List<Course>();
            foreach (int courseId in courseIds)
            {

                var course = await _db.Courses.FindAsync(courseId);
                if (course == null)
                {
                    return null;
                }
                temp.Add(course);
            }
            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Courses = temp
            };

            _db.Students.Add(student);
            _db.SaveChanges();
            return student;
        }

        public async Task<bool?> DeleteStudent(int studentId)
        {
            //TODO: (go in to courses and delete all referenses to spesific student) 

            var student = await _db.Students.FindAsync(studentId);

            if (student == null) 
            { return null; }

            _db.Students.Remove(student);
            _db.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course?> GetCourse(int courseId)
        {
            var coruse = await _db.Courses.FindAsync(courseId);

            return coruse;
        }

        public async Task<Course?> UpdateCourse(int courseId, string courseTitle, string courseStartDate, int averageGrade)
        {
            var course = await _db.Courses.FindAsync(courseId);
            if (course == null)
            {
                return null;
            }

            course.Id = courseId;
            course.CourseTitle = courseTitle;
            course.CourseStartDate = courseStartDate;
            course.grade = averageGrade; //TODO: when many to many. grade can be the average of the currently enrolled students
            
            _db.SaveChanges();
            return course;
        }

        public async Task<Course> CreateCourse(string courseTitle, string courseStartDate, int averageGrade)
        {
            
            Course course = new Course()
            {
                CourseTitle = courseTitle,
                CourseStartDate = courseStartDate,
                grade = averageGrade //TODO: when many to many. grade can be the average of the currently enrolled students

        };

            _db.Courses.Add(course);
            _db.SaveChanges();
            return course;
        }

        public async Task<bool?> DeleteCourse(int courseId)
        {
            var course = await _db.Courses.FindAsync(courseId);

            if (course == null)
            { return null; }

            _db.Courses.Remove(course);
            _db.SaveChanges();
            return true;
        }
    }
}
