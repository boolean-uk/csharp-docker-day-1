using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> AddStudent(Student student); 
        Task<Student> UpdateStudent(Student student, int id);
        Task<Student> DeleteStudent(int id);
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourseById(int id);
        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course, int id);
        Task<Course> DeleteCourse(int id);
    }

}
