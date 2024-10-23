using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]
    public class Course
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("average_grade")]
        public float AverageGrade { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
