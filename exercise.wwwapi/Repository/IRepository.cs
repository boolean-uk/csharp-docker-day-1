using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<StudentPayload>> GetStudents();
        Task<StudentPayload> AddStudent(InputStudentDTO entity);
        Task<StudentPayload> UpdateStudent(int id, InputStudentDTO entity);
        Task<StudentPayload> RemoveStudent(int id);
        Task<IEnumerable<CoursePayload>> GetCourses();
    }

}
