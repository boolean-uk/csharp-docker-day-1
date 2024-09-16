using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        // --- Student ---
        Task<Student> AddStudent(Student entity);
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> UpdateStudent(int id, Student entity);
        Task<Student> DeleteStudent(Student entity);

        // --- Course ---
        Task<Course> AddCourse(Course entity);
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int id);
        Task<Course> UpdateCourse(int id, Course entity);
        Task<Course> DeleteCourse(Course entity);
    }

}
