using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public enum PreloadPolicy
    {
        PreloadRelations,
        DoNotPreloadRelations
    }
    public interface IRepository
    {
        Task<IEnumerable<Student>> GetStudents();
      
        Task<Student?> GetStudent(int studentId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        Task<Student?> CreateStudent(string FirstName, string LastName, DateTime DOB, float AverageGrade);

        Task<Student?> DeleteStudent(int StudentId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);

        Task<Student?> UpdateStudent(int studentId, string? FirstName, string? LastName, DateTime? DOB, float? AverageGrad, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);



        Task<IEnumerable<Course>> GetCourses();
        Task<Course?> GetCourse(int courseId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Course?> CreateCourse(string Title, string Teacher, DateTime StartDate);

        Task<Course?> DeleteCourse(int courseId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<Course?> UpdateCourse(int courseId, string? Title, string? Teacher, DateTime? StartDate, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);


        Task<IEnumerable<CourseStudent>> GetCourseStudents();

        Task<CourseStudent?> GetCourseStudent(int courseId, int studentId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations);
        Task<CourseStudent?> CreateCourseStudent(int courseId, int studentId);

        Task<CourseStudent?> DeleteCourseStudent(int CourseId, int StudentId, PreloadPolicy preloadPolicy = PreloadPolicy.PreloadRelations);

        public void SaveChanges();
    }

}
