using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CoursePayload
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public DateOnly CourseStartDate { get; set; }
        public string AverageGrade { get; set; }
        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();

        public CoursePayload(Course course)
        {
            this.Id = course.Id;
            this.CourseTitle = course.CourseTitle;
            this.CourseStartDate = course.CourseStartDate;
            this.AverageGrade = course.AverageGrade;
            foreach (var student in course.StudentCourses)
            {
                this.Students.Add(new StudentDTO(student.Student));
            }
        }
    }
}
