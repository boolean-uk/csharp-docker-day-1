using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Course>> GetCourses();
        Task<Student> GetStudentById(int id);
        Task<Course> GetCourseById(int id);
        Task<Student> UpdateStudent(Student student);
        Task<Course> UpdateCourse(Course course);
        Task<Student> AddStudent(Student student);
        Task<Course> AddCourse(Course course);
        Task<Student> DeleteStudent(Student student);
        Task<Course> DeleteCourse(Course course);
    }

}
