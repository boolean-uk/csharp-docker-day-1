using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataModels.DTOs;
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
            return await _db.Courses.Include(c => c.Students).ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.Include(c => c.Course).ToListAsync();
        }

        public async Task<Course> GetCourse(int id)
        {
            var course = await _db.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == id);
            if (course == null)
                throw new KeyNotFoundException("Course not found");

            return course;
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
                throw new KeyNotFoundException("Student not found");

            return student;
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

            var addedStudent = await _db.Students
            .Include(s => s.Course)  
            .FirstOrDefaultAsync(s => s.Id == student.Id);

            return addedStudent;
        }

        public async Task<Course> UpdateCourse(PatchCourseDTO course, int id)
        {
            var existingCourse = await _db.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == id);
            if (existingCourse == null)
                throw new KeyNotFoundException("Course not found");


            if (!string.IsNullOrEmpty(course.Title))
                existingCourse.Title = course.Title;

            if (course.StartDate.HasValue)
                existingCourse.StartDate = course.StartDate.Value;

            if (course.AverageGrade.HasValue)
                existingCourse.AverageGrade = course.AverageGrade.Value;

            _db.Courses.Update(existingCourse);
            await _db.SaveChangesAsync();

            return existingCourse; 
        }

        public async Task<Student> UpdateStudent(PatchStudentDTO student, int id)
        {
            var existingStudent = await _db.Students.Include(c => c.Course).FirstOrDefaultAsync(c => c.Id == id);
            if (existingStudent == null)
                throw new KeyNotFoundException("Student not found");


            if (!string.IsNullOrEmpty(student.FirstName))
                existingStudent.FirstName = student.FirstName;

            if (!string.IsNullOrEmpty(student.LastName))
                existingStudent.LastName = student.LastName;

            if (student.DateOfBirth.HasValue)
                existingStudent.DateOfBirth = student.DateOfBirth.Value;

            if (student.CourseId.HasValue)
                existingStudent.CourseId = student.CourseId.Value;

            _db.Students.Update(existingStudent);
            await _db.SaveChangesAsync();

            return existingStudent;
        }

        public async Task<Course> DeleteCourse(int id)
        {
            var existingCourse = await _db.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == id);
            if (existingCourse == null)
                throw new KeyNotFoundException("Course not found");

            _db.Courses.Remove(existingCourse);

            await _db.SaveChangesAsync();

            return existingCourse;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var existingStudent = await _db.Students.Include(s => s.Course).FirstOrDefaultAsync(s => s.Id == id);
            if (existingStudent == null)
                throw new KeyNotFoundException("Student not found");

            _db.Students.Remove(existingStudent);

            await _db.SaveChangesAsync();

            return existingStudent;
        }

    }
}
