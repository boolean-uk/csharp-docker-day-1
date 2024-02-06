using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> AddStudent(string firstName, string lastName, DateTime Birthdate, string CourseTitle, DateTime CourseStartDate, float averageGrade);
        Task<Student?> UpdateStudent(int id, string? firstName = null, string? lastName = null, DateTime? birthdate = null, string? courseTitle = null, DateTime? courseStartDate = null, float averageGrade = float.NaN);
        Task<Student?> DeleteStudent(int id);
    }
}
