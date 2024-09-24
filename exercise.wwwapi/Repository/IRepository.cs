using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<StudentDTO>> GetStudents();
        Task<IEnumerable<CourseDTO>> GetCourses();
        Task<StudentDTO> GetStudentById(int id);
        Task<StudentDTO> CreateStudent(StudentPutPost student);
        Task<StudentDTO> UpdateStudent(int id, StudentPutPost response);
        Task<StudentDTO> DeleteStudent(int id);
        Task<CourseDTO> GetCourseById(int id);
        Task<CourseDTO> CreateCourse(CoursePutPost course);
        Task<CourseDTO> UpdateCourse(int id, CoursePutPost response);
        Task<CourseDTO> DeleteCourse(int id);
    }

}
