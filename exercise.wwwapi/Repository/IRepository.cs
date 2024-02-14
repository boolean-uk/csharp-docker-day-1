using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> DeleteStudent(int id);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(int id, Student student);

        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int id);
        Task<Course> DeleteCourse(int id);
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(int id, Course course);
    }

}
