using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Payloads
{
    public class CoursePayload
    {
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}", ErrorMessage = "Invalid Format. Expected Format: YYYY-MM-DD")]
        public string StartDate { get; set; }

        public string CourseTitle { get; set; }

    }
}
