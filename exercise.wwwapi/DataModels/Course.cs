using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string? CourseTitle { get; set; }
        public DateTime StartDate { get; set; }
        public string? AverageGrade { get; set; }
        public ICollection<CourseDetails> CourseDetails { get; set; }
    }
}
