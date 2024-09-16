using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("Course")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("average_grade")]
        public double AverageGrade { get; set; }
    }
}
