using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.ViewModels
{
    public class StudentPost
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public decimal AverageGrade { get; set; }
    }
}
