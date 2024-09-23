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

        [Column("title")]
        public string Title { get; set; }

        [Column("startTime")]
        public DateTime StartTime { get; set; }

        [Column("averageGrade")]
        public double AverageGrade { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
