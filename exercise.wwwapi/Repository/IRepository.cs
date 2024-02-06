using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Course>> GetCourses();

        Task<Student> GetStudentById(int id);
        Task<Course> GetCourseById(int id);

        Task<Student> AddStudent(Student student);
        Task<Course> AddCourse(Course course);

        Task<Student> UpdateStudent(int id, Student student);
        Task<Course> UpdateCourse(int id, Course course);

        Task<Student> DeleteStudent(int id);
        Task<Course> DeleteCourse(int id);

        Task<Student>AddCourseOnStudent(int id, int courseId);
    }

}
