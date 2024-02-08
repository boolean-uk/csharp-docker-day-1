using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student?> GetStudent(int id);
        Task<Student?> UpdateStudent(int id, string FirstName, string LastName, string Dob, int CourseId, int AvgGrade);
        Task<Student> CreateStudent(string FirstName, string LastName, string Dob, int CourseId, int AvgGrade);
        Task<Student?> DeleteStudent(int id);
        Task<IEnumerable<Course>> GetCourses();
        Task<Course?> GetCourse(int id);
        Task<Course?> UpdateCourse(int id, string Title, string Description, string StartDate);
        Task<Course> CreateCourse(string Title, string Description, string StartDate);
        Task<Course?> DeleteCourse(int id);
        Task<Join_student_course?> CreateEnrollment(Student Student, Course Course);
    }

}
