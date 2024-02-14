using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataTransferObjects;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        //*************** Student ****************
        Task<IEnumerable<Student>> GetStudents();

        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(int id, StudentPayload payload);

        Task<Student> DeleteStudent(int id);


        //******************* Course **************
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> CreateCourse(Course course);
    }

}
