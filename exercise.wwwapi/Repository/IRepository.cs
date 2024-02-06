using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> getStudents();
        Task<Student?> createStudent(string first_name, string last_name, DateTimeOffset d_o_b);
        Task<Student?> updateStudent(int id, string? first_name, string? last_name, DateTimeOffset? d_o_b);
        Task<Student?> deleteStudent(int id);
        Task<IEnumerable<Course>> getCourses();
        Task<Course?> createCourse(string course_title, DateTimeOffset course_start_date);
        Task<Course?> updateCourse(int id, string? course_title, DateTimeOffset? course_start_date);
        Task<Course?> deleteCourse(int id);
    }

}
