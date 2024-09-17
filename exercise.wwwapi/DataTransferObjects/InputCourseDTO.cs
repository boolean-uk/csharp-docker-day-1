using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataTransferObjects
{
    public class InputCourseDTO
    {
        public string CourseTitle { get; set; }

        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Invalid Format. Expected Format: YYYY-MM-DD")]
        public string CourseStartDate { get; set; }
    }
}
