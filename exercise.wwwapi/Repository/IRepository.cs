using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();

        Task<Student> GetStudent(int id);

        Task<Student> AddStudent(Student student);

        Task<Student> UpdateStudent(Student student);

        Task<Student> DeleteStudent(int id);
        Task<IEnumerable<Course>> GetCourses();

        Task<Course> GetCourse(int id);

        Task<Course> AddCourse(Course course);

        Task<Course> UpdateCourse(Course course);

        Task<Course> DeleteCourse(int id);


    }

}
