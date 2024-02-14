using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects.Courses
{
    public class CourseDTO(Course course)
    {
        public int Id { get; set; } = course.Id;

        public string CourseTitle { get; set; } = course.CourseTitle;

        public string CourseStartDate { get; set; } = course.CourseStartDate.ToString("yyyy-MM-dd");

        public int NumberOfStudents { get; set; } = course.Students.Count;
    }
}
