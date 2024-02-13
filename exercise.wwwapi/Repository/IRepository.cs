using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        // Task<IEnumerable<Course>> GetCourses();
        Task<T> Add(T input);
        Task<T> UpdateById(T input, int id);
        Task<T> DeleteById(int id);
        Task<T> GetById(int id);
        Task<Course> DeleteCourseById(int id);
    }

}
