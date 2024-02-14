using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("Student")]
    public class Student
    {
        [Column("Student_Id")]
        public int id { get; set; }

        [Column("First_Name")]
        public string First_Name { get; set; }

        [Column("Last_Name")]
        public string Last_Name { get; set; }

        [Column("Date_Of_Birth")]
        public DateTime Date_Of_Birth { get; set; }

       
        [Column("Course_Id")] 
        public int CourseId { get; set; }

        [ForeignKey("CourseId")] 
        public Course Course { get; set; }

        [Column("Average_Grade")]
        public float Average_Grade { get; set; }

    }
}
