using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }
        
        [Column("start_date")]
        public DateTime StartDate { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}
