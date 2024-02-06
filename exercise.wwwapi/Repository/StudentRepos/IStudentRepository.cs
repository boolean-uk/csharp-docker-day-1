using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> AddStudent(string firstName, string lastName, DateTime Birthdate, float averageGrade);
        Task<Student?> UpdateStudent(int id, string? firstName = null, string? lastName = null, DateTime? birthdate = null, float averageGrade = float.NaN);
        Task<Student?> DeleteStudent(int id);
        Task<Student?> ApplyToCourse(int id, int courseId);
        Task<Student?> LeaveCourse(int studentId);
    }
}
