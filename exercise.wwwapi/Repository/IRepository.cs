using exercise.wwwapi.DataModels;
using System.Threading.Tasks;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        //Student
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student, int id);
        Task<Student> DeleteStudent(int id);

    }

}
