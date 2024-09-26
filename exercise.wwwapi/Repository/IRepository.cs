using exercise.wwwapi.DataModels;
using exercise.wwwapi.DataModels.DTOs;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Course>> GetCourses();

        Task<Course> GetCourse(int id);

        Task<Student> GetStudent(int id);
        Task<Course> AddCourse(Course course);

        Task<Student> AddStudent(Student student);
        Task<Course> UpdateCourse(PatchCourseDTO course, int id);

        Task<Student> UpdateStudent(PatchStudentDTO student, int id);

        Task<Course> DeleteCourse(int id);

        Task<Student> DeleteStudent(int id);


    }

}
