using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<Student> CreateStudent(PostStudent student);
        Task<IEnumerable<Student>> GetStudents();

        Task<Student> GetStudent(int id);

        Task<Student> UpdateStudent(int id, PutStudent student);

        Task<Student> DeleteStudent(int id);


        Task<Course> CreateCourse(PostCourse course);
        Task<IEnumerable<Course>> GetCourses();

        Task<Course> GetCourse(int id);

        Task<Course> UpdateCourse(int id, PutCourse course);
        Task<Course> DeleteCourse(int id);
    }

}
