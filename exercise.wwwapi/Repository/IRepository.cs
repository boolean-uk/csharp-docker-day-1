using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetACourse(int id);
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<Course> DeleteCourse(Course course);
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetAStudent(int id);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(Student student);
    }

}
