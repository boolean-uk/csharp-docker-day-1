using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    public class CoursePut
    {
        public string? Title { get; set; }
        public DateTime? CourseStart { get; set; }
        public double? AverageGrade { get; set; }
    }
}
