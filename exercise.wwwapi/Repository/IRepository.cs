using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student?> GetStudentByID(int id);
        Task<Student> CreateStudent(string firstName, string lastName, string dateOfBirth);
        Task<Student> UpdateStudent(Student student, string? firstName, string? lastName, string? dateOfBirth);
        Student DeleteStudent(Student student);
        Task<IEnumerable<Course>> GetCourses();
        Task<Course?> GetCourseByID(int id);
        Task<Course> CreateCourse(string courseTitle, string startDate);
        Task<Course> UpdateCourse(Course course, string? courseTitle, string? startDate);
        Course DeleteCourse(Course course);


    }

}
