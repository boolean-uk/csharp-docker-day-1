using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{   
    [Table("Courses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("start_date")]
        public string StartDate { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
