using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects.Students
{
    public class StudentCourseDTO(Course course)
    {
        public int CourseId { get; set; } = course.Id;

        public string CourseName { get; set; } = course.CourseTitle;

        public string CourseStartDate { get; set; } = course.CourseStartDate.ToString("yyyy-MM-dd");
    }
}
