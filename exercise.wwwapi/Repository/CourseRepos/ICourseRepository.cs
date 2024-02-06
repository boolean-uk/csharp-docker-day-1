using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetCourses();
    Task<Course> AddCourse(string title, string description, int availableSpots, DateTime startDate, DateTime endDate);
    Task<Course?> UpdateCourse(int id, string? title = null, string? description = null, int? availableSpots = null, DateTime? startDate = null, DateTime? endDate = null);
    Task<Course?> DeleteCourse(int id);
}
