using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("course_title")]
        public string CourseTitle { get; set; }
        [Column("start_date")]
        public string StartDate { get; set; }
        public ICollection<Registration> Registrations { get; set; }

    }

    public record CoursePayload(string courseTitle, string startDate);
}
