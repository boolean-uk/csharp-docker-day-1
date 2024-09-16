using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.Payload
{
    public class CustomerPayload
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> CourseIds { get; set; } = new List<int>();
        public int AverageGrade { get; set; }

        [RegularExpression(@"^\d{4}-\d{2}-\d{2}", ErrorMessage = "Invalid Format. Expected Format: YYYY-MM-DD")]
        public string DateOfBirth { get; set; }

    }
}
