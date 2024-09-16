using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetACourse(int id);
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<Course> DeleteCourse(Course course);
    }

}
