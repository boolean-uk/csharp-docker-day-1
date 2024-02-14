using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> CreateStudent(CreateStudentPayload payload);
        Task<Student> UpdateStudent(int id, UpdateStudentPayload payload);
        Task DeleteStudent(int id);


        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int id);
        Task<Course> CreateCourse(CreateCoursePayload payload);
        Task<Course> UpdateCourse(int id, UpdateCoursePayload payload);
        Task DeleteCourse(int id);

        Task<Student> AddStudentToCourse(CreateOrUpdateStudentCoursePayload payload);
        Task<IEnumerable<Student>> GetStudentsByCourse(int courseId);
        Task<IEnumerable<Course>> GetCoursesByStudent(int studentId);
        
    }

}
