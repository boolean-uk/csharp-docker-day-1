using exercise.wwwapi.DataModels;
using exercise.wwwapi.DTO;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        // GET
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Course>> GetCourses();

        // GET BY ID
        Task<Student> GetStudentById(int id);
        Task<Course> GetCourseById(int id);

        // POST
        Task<Student> AddStudent(Student student);
        Task<Course> AddCourse(Course course);

        // ADD/REMOVE STUDENT COURSE
        Task AddStudentToCourse(int studentId, int courseId);

        Task RemoveStudentFromCourse(int studentId, int courseId);

        // PUT
        Task<Student> UpdateStudent(int id, Student student);
        Task<Course> UpdateCourse(int id, Course course);

        // DELETE
        Task<bool> DeleteStudent(int id);
        Task<bool> DeleteCourse(int id);
    }

}
