using exercise.wwwapi.DataModels;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Course>> GetCourses();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }

}
