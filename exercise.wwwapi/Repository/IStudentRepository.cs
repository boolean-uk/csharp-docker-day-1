using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<IEnumerable<Course>> GetCourses();

        Task<Student> CreateStudent(Student entity);

        Task<Student> UpdateStudent(Student entity);

        Task<Student> DeleteStudent(Student entity);


    }

}
