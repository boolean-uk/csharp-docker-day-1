using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCourses();
        Task<Course?> GetCourseById(int id);
        Task<Course> CreateCourse(Course Course);
        Task<Course?> UpdateCourseById(int id, Course CourseUpdateData);
        
        Task<Course?> DeleteCourseById(int id);

    }

}
