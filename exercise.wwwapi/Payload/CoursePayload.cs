using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Payload
{
    public class CoursePayload
    {
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}", ErrorMessage = "Invalid Format. Expected Format: YYYY-MM-DD")]
        public string StartDateForCourse { get; set; }

        public string CourseName { get; set; }
    }
}
