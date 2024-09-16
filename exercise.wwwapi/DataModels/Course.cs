using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("startdate")]
        public DateTime StartDate { get; set; }
        [Column("avggrade")]
        public decimal AvgGrade { get; set; }
    }
}
