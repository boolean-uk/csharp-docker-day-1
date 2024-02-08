using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student?> GetStudent(int id);
        Task<Student?> AddStudent(string firstname, string lastname, string birthday, string grade, int courseId);
        Task<Student>? ChangeStudent(Student student, string? firstname, string? lastname, string? birthday, string? grade, int? courseId);
        Task<IEnumerable<Student>> RemoveStudent(Student student);

        Task<IEnumerable<Course>> GetCourses();
        Task<Course?> GetCourse(int id);
        Task<Course?> AddCourse(string title, DateTime startDate);
        Task<Course>? ChangeCourse(Course course, string? title, DateTime? startDate);
        Task<IEnumerable<Course>> RemoveCourse(Course course);
    }
}