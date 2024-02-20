using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        // Student
        Task<Student> Create(StudentPost student);
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> Update(StudentPut student, int id);
        Task<Student> Delete(int id);

        // Course (Extension)
        Task<Course> CreateCourse(CoursePost course);
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> UpdateCourse(CoursePut course, int id);
        Task<Course> DeleteCourse(int id);
    }

}
