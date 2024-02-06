using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("course_title")]
        public string CourseTitle { get; set; }
        [Column("course_start_date")]
        public DateTimeOffset CourseStartDate { get; set; }
        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
