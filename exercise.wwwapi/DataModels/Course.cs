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

        [Column("start")]
        public DateOnly StartDate { get; set; }

        [Column("grade")]
        public double AvgGrade { get; set; }


    }
}
