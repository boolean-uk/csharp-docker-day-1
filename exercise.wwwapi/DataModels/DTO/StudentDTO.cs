using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels.DTO
{
    public class StudentDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public DateTime CourseStart { get; set; }
        public double AverageScore { get; set; }
        public int CourseId { get; set; }

    }
}
