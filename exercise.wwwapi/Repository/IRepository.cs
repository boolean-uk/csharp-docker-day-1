using exercise.wwwapi.DataModels;
using exercise.wwwapi.Endpoints;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Course>> GetCourses();

        Task<Student> AddStudent(string name);

        Task<Student> DeleteStudent(int id);

        Task<Student> UpdateStudent(int id, string name);

        Task<Course> AddCourse(string name);

        Task<Course> DeleteCourse(int id);

        Task<Course> UpdateCourse(int id, string name);









    }

}
