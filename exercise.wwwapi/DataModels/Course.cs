using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string CourseTitle { get; set; }
        [Column("start_date")]
        public DateOnly StartDate { get; set; }

        public ICollection<Enrollments> Enrollments { get; set; }
    }
}
