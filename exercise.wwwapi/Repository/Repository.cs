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

        public async Task<Course> AddCourse(Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Student> AddStudent(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            student = await _db.Students.Include(s => s.Course).SingleOrDefaultAsync(c => c.Id == student.Id);
            return student;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include( s => s.Course).ToListAsync();
        }

        public async Task<Course> UpdateCourse(int id, Course course)
        {
            Course dbCourse = await _db.Courses.SingleOrDefaultAsync(c => c.Id == id);
            dbCourse.Name = course.Name;
            dbCourse.AverageGrade = course.AverageGrade;
            _db.Attach(dbCourse).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return dbCourse;
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            Student dbStudent = await _db.Students.Include(s => s.Course).SingleOrDefaultAsync(c => c.Id == id);
            dbStudent.FirstName = student.FirstName;
            dbStudent.LastName = student.LastName;
            dbStudent.DateOfBirth = student.DateOfBirth;
            dbStudent.CourseID = student.CourseID;
            _db.Attach(dbStudent).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            dbStudent = await _db.Students.Include(s => s.Course).SingleOrDefaultAsync(c => c.Id == id);
            return dbStudent;
        }
    }
}
