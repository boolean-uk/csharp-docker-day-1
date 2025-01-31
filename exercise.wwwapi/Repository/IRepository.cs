using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Course>> GetCourses();
        Task<Student> GetStudent(int id);
        Task<Course> GetCourse(int id);
        Task<Student> AddStudent(StudentDTO studentDTO);
        Task<Course> AddCourse(CourseDTO courseDTO);
        Task<Student> AddStudentToCourse(int studentId, int courseId);

        Task<Student> UpdateStudent(Student student);
        Task<Course> UpdateCourse(Course course);
        Task<Student> DeleteStudent(int id);
        Task<Course> DeleteCourse(int id);
    }

}
