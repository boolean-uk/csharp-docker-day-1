using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> CreateStudent(Student student);
        Task<Student> DeleteStudent(int id);
        Task<Student> UpdateStudent(Student student, int id);


        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int id);
    }

}
