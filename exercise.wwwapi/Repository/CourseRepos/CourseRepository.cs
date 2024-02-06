using exercise.wwwapi.Data;
using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private DataContext _db;
        public CourseRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _db.Courses.Include(c => c.Students).ToListAsync();
        }

        public async Task<Course> AddCourse(string title, string description, int availableSpots, DateTime startDate, DateTime endDate)
        {
            var newCourse = await _db.Courses.AddAsync(
                new Course
                {
                    Title = title,
                    Description = description,
                    AvailableSpots = availableSpots,
                    StartDate = startDate,
                    EndDate = endDate
                });

            await _db.SaveChangesAsync();
            return newCourse.Entity;
        }

        public async Task<Course?> UpdateCourse(int id, string? title = null, string? description = null, int? availableSpots = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (course == null) { return null; }

            if (!string.IsNullOrWhiteSpace(title)) { course.Title = title; }
            if (!string.IsNullOrWhiteSpace(description)) { course.Description = description; }
            if (availableSpots != null) { course.AvailableSpots = (int)availableSpots; }
            if (startDate.HasValue) { course.StartDate = startDate.Value; }
            if (endDate.HasValue) { course.EndDate = endDate.Value; }

            await _db.SaveChangesAsync();

            return course;
        }
        public async Task<Course?> DeleteCourse(int id)
        {
            var course = await _db.Courses.FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (course == null) { return null; }

            _db.Courses.Remove(course);

            await _db.SaveChangesAsync();
            return course;
        }
    }
}
