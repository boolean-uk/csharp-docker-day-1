using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> CreateStudent(string firstname, string lastname, DateTime dateOfBirth, int avgGrade);
        Task<Student> GetStudentById(int id);
        Task<Student> UpdateStudent(int id, string firstname, string lastname, DateTime dateOfBirth, int avgGrade);
        Task<Student> DeleteStudent(int id);
        Task<IEnumerable<Course>> GetCourses();

        Task<Course> CreateCourse(string title, DateTime startDate);
        Task<Course> GetCourseById(int id);
        Task<Course> UpdateCourse(int id, string title, DateTime startDate);
        Task<Course> DeleteCourse(int id);

        public Task<Student> EnrollStudent(int studentid, int courseid);
    }

}
