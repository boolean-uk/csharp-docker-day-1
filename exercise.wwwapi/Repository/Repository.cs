using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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
            return await _db.Students.ToListAsync();
        }

        public async Task<Student> CreateStudent(Student student)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(c => c.Title == student.CourseTitle);
            if (course == null)
            {
                throw new Exception("Course with the given title does not exist");
            }


            int maxStudentId = await _db.Students.MaxAsync(a => (int?)a.Id) ?? 0;

            int newStudentId = maxStudentId + 1;

            var newStudent = new Student()
            { 
                Id = newStudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                CourseTitle = student.CourseTitle,
                StartDate = student.StartDate,
                AvgGrade = student.AvgGrade,
                CourseId = student.CourseId

            };

            await _db.Students.AddAsync(newStudent);
            await _db.SaveChangesAsync();

            return student;
        }

        public async Task<Student> UpdateStudent(int id, StudentPayload payload)
        {
            
            var found = await _db.Students.FindAsync(id);
            if (found == null)
            {
                return null;
            }

            found.FirstName = payload.FirstName;
            found.LastName = payload.LastName;
            found.CourseTitle = payload.CourseTitle;
            found.AvgGrade = payload.AvgGrade;

            await _db.SaveChangesAsync();

            return found;
        }


        public async Task<Student> DeleteStudent(int id)
        {
            var found = await _db.Students.FindAsync(id);

            if(found == null)
            {
                return null;
            }

            _db.Students.Remove(found);
            await _db.SaveChangesAsync();
            return found;
        }



        //*********************** Course *******************
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course> CreateCourse(Course course)
        {
            int maxCourseId = await _db.Courses.MaxAsync(a => a.Id);

            int newCourseId = maxCourseId + 1;

            var newCourse = new Course
            { 
                Id = newCourseId,
                Title = course.Title,
            };

            _db.Courses.AddAsync(newCourse);
            await _db.SaveChangesAsync();
            return newCourse;
        }
    }
}
