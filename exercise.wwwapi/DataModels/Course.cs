using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("teacher")]
        public string Teacher { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        // a course can have many students in it 
        public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
    }
}
