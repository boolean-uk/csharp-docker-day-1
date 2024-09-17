using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Payloads
{
    public class StudentPayload
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [RegularExpression(@"^\d{4}-\d{2}-\d{2}", ErrorMessage = "Invalid Format. Expected Format: YYYY-MM-DD")]
        public string DateOfBirth { get; set; }

        public List<int> CourseIds { get; set; } = new List<int>();
        public int AverageGrade { get; set; }
    }
}
