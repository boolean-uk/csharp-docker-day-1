using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<List<Student>> GetStudents();
        Task<Student?> GetStudentById(int id);
        Task<Student> CreateStudent(Student Student);
        Task<Student?> UpdateStudentById(int id, Student StudentUpdateData);
        
        Task<Student?> DeleteStudentById(int id);

        Task<IEnumerable<Course>> GetCourses();
    }

}
