using exercise.wwwapi.DataTransferObjects.CourseDTOs;
using exercise.wwwapi.DataTransferObjects.StudentDTOs;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<GetStudentDTO>> GetStudents();
        Task<GetStudentDTO?> GetStudentById(int id);
        Task<GetStudentDTO?> CreateStudent(CreateStudentDTO cDTO);
        Task<GetStudentDTO?> UpdateStudent(int studentId, UpdateStudentDTO uDTO);
        Task<GetStudentDTO?> DeleteStudent(int studentId);
        Task<IEnumerable<GetCourseDTO>> GetCourses();
        Task<GetCourseDTO?> GetCourseById(int id);
        Task<GetCourseDTO> CreateCourse(CreateCourseDTO cDTO);
        Task<GetCourseDTO?> UpdateCourse(int courseId, UpdateCourseDTO uDTO);
        Task<GetCourseDTO?> DeleteCourse(int courseId);
    }

}
