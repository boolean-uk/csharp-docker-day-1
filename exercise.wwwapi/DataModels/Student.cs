using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("student")]
    public class Student : IClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("student_id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("dob", TypeName = "Date")]
        public DateTime DoB { get; set; }

        [Column("average_grade")]
        public double AverageGrade { get; set; }

        /*[Column("course_title")]
        public string Title { get; set; }

        [Column("start_date_course", TypeName = "Date")]
        public DateTime? CourseStartDate { get; set; }

        [Column("avg_grade")]
        public int AvgGrade { get; set; }*/


        // If want to use many to many
        /* [Column("course_id")]
         public List<Course> Courses { get; } = new List<Course>();*/

        // For many to one:
        [ForeignKey("course_id")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
