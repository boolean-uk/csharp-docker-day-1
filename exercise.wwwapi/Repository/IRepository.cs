using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student?> GetStudent(int id);
        Task<Student?> UpdateStudent(int id, string FirstName, string LastName, string Dob, string CourseTitle, string StartDate, int AvgGrade);
        Task<Student> CreateStudent(string FirstName, string LastName, string Dob, string CourseTitle, string StartDate, int AvgGrade);
        Task<Student?> DeleteStudent(int id);
        Task<IEnumerable<Course>> GetCourses();
    }

}
