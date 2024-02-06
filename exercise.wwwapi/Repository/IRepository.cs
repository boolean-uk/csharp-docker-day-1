using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student?> GetStudentByID(int id);
        Task<Student> CreateStudent(string firstName, string lastName, string dateOfBirth, string courseTitle, string startDate, float averageGrade);
        Task<Student> UpdateStudent(Student student, string? firstName, string? lastName, string? dateOfBirth, string? courseTitle, string? startDate, float? averageGrade);
        Student DeleteStudent(Student student);
        Task<IEnumerable<Course>> GetCourses();
    }

}
