using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> CreateStudent(Student student);
        Task<IEnumerable<Course>> GetCourses();
        Task<Student> DeleteStudent(Student student);
        Task<Student> EditStudent(Student student, string name);
        Task<Student> GetStudentById(int id);
    }

}
