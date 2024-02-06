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

        public async Task<Course?> DeleteCourseById(int id)
        {
            Course? course = await  GetCourseById(id);
            if (course == null) { return null; }
             _db.Courses.Remove(course);
            _db.SaveChanges();
            return course;
        }



        public async Task<Course?> GetCourseById(int id)
        {
            return await _db.Courses.Include(c => c.students).FirstOrDefaultAsync(s => s.Id == id);

        }

        public async Task<List<Course>> GetCourses()
        {
            return await _db.Courses.Include(c => c.students).ToListAsync();
        }

        public async Task<Course?> UpdateCourseById(int id, Course CourseUpdateData)
        {
            Course? course = await GetCourseById(id);
            if (course == null) { return null; }

            _db.SaveChanges();
            return course;



        }
  
        public async Task<Course> CreateCourse(Course Course)
        {
            await _db.Courses.AddAsync(Course);
            _db.SaveChanges();
            return  Course;
        }
    }
}
