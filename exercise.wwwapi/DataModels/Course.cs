using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("course")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("startDate")]
        public DateTime StartDate { get; set; }

        [Column("averageGrade")]
        public float AverageGrade { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
