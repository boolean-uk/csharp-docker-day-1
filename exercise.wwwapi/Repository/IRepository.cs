using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<StudentDTO>> GetStudents();
        Task<IEnumerable<CourseDTO>> GetCourses();
    }

}
