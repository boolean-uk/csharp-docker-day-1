using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(CreateCourseDTO createCourseDTO, int id);
        Task<Course> GetCourse(int id);
        Task<Course> DeleteCourse(int id);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(CreateStudentDTO createStudentDTO, int id);
        Task<Student> DeleteStudent(int id);
    }

}
