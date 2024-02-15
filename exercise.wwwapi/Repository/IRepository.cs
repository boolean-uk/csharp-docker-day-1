using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<IEnumerable<Student>> GetAllStudentsWithCourses();
        Task<Student> GetSpecificStudentWithCourses(int id);
    }

}
