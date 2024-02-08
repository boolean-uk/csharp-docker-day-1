using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<Student>> GetStudents();

        public Task<Student?> GetAStudent(int id);
        public Task<Student?> CreateStudent(string FirstName, string LastName, DateOnly DateOfBirth, float avgGrade);
        public Task<Student?> UpdateStudent(int id, string newFirstName, string newLastName, DateOnly DateOfBirth, float avgGrade);
        public Task<Student?> DeleteStudent(int id);

        public Task<IEnumerable<Course>> GetCourses();
        public Task<Course?> GetACourse(int id);

        public Task<Course?> CreateCourse(string CourseTitle, DateOnly startDate);
        public Task<Course?> UpdateCourse(int id, string newTitle, DateOnly newStartDate);
        public Task<Course?> DeleteCourse(int id);
    }

}
