using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataTransferObjects
{
    public class InputStudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Invalid Format. Expected Format: YYYY-MM-DD")]
        public string BirthDate { get; set; }
        public List<int> CourseIds { get; set; } = new List<int>();
    }
}
