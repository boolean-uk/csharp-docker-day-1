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
        public required string Title { get; set; }

        [Column("course_description")]
        public required string Description { get; set; }

        [Column("available_spots")]
        public required int AvailableSpots { get; set; }

        [Column("start_date")]
        public required DateTime StartDate { get; set; }

        [Column("end_date")]
        public required DateTime EndDate { get; set; }

        public ICollection<Student> Students { get; } = new List<Student>();
    }
}