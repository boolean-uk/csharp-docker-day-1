using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> CreateStudent(Student entity);
        Task<IEnumerable<Course>> GetCourses();
        Task<Student> GetStudentById(int id);
        Task<Student> EditStudent(Student entity);
        Task<Student> DeleteStudent(int id);
    }

}
