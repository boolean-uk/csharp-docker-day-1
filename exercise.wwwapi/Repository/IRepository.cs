using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;
using exercise.wwwapi.Payloads;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<StudentDTO>> GetStudents();
        Task<StudentDTO> GetStudent(int studentId);
        Task<StudentDTO> CreateStudent(StudentPayload payload);
        Task<StudentDTO> UpdateStudent(int studentId, StudentPayload payload);
        Task<StudentDTO> DeleteStudent(int studentId);


        Task<IEnumerable<CourseDTO>> GetCourses();
        Task<CourseDTO> GetCourse(int courseId);
        Task<CourseDTO> CreateCourse(CoursePayload payload);
        Task<CourseDTO> UpdateCourse(int courseId, CoursePayload payload);
        Task<CourseDTO> DeleteCourse(int courseId);

    }

}
