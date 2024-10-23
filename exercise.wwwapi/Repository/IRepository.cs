using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Course>> GetCourses();
        Task<Student> GetStudent(int id);
        Task<Course> GetCourse(int id);
        Task<Student> DeleteStudent(int id);
        Task<Course> DeleteCourse(int id);

        Task<Student> CreateStudent(StudentDTO student);
        Task<Course> CreateCourse(CourseDTO course);
    }

}
