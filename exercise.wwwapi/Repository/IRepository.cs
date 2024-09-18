using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<List<Student>> GetStudents();
        Task<IEnumerable<Course>> GetCourses();
    }

}
