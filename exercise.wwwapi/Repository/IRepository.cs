using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
  
        Task<Student> DeleteStudent(int id);
        Task<Student> UpdateStudent(int id, Student updatedStudent);

        Task<Student> CreateStudent(StudentPost studentPost);

        Task<IEnumerable<Course>> GetCourses();
        Task<Course> DeleteCourse(int id);
        Task<Course> UpdateCourse(int id, Course updatedCourse);
        Task<Course> CreateCourse(Course course);
    }

}
