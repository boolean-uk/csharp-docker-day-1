using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student?> GetStudent(int studentId);
        Task<Student> CreateStudent(Student student);
        Task<Student?> UpdateStudent(int studentId, Student student);
        Task<Student?> DeleteStudent(int studentId);
        Task<IEnumerable<Course>> GetCourses();
    }

}
