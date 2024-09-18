using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetAStudent(int id);
        Task<IEnumerable<Course>> GetCourses();
        Task<Student> AddStudent(Student student);
        Task<Course> GetACourse(int id);
        Task<Course> AddCourse(Course entity);
        Task<bool> DeleteCourse(int id);
        Task<Course> UpdateCourse(int id, Course entity);
    }

}
