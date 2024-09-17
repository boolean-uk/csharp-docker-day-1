using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] 
        public int Id { get; set; }


        [Column("start_date_of_courses")]
        public DateOnly StartDateForCourse { get; set; }


        [Column("course_title")]
        public string CourseTitle { get; set; }
    }
}
