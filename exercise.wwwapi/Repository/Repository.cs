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
            return await _db.Courses.ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _db.Students.ToListAsync();
        }

        public async Task<Course> AddCourse(Course course)
        {
            _db.Courses.Add(course);

            await _db.SaveChangesAsync();

            return course;
        }

        public async Task<Course> UpdateCourse(PatchCourseDTO course, int id)
        {
            var existingCourse = await _db.Courses.FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<Course> DeleteCourse(int id)
        {
            var existingCourse = await _db.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (existingCourse == null)
                throw new KeyNotFoundException("Course not found");

            _db.Courses.Remove(existingCourse);

            await _db.SaveChangesAsync();

            return existingCourse;
        }
    }
}
