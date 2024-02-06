using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("dob")]
        public string DoB { get; set; }
        [Column("course_title")]
        public string CourseTitle { get; set; }
        [Column("start_date")]
        public string StartDate { get; set; }
        [Column("avg_grade")]
        public int AvgGrade { get; set; }
    }
}
//Unique ID
//First Name
//Last Name
//Date of Birth
//Course Title
//Start Date for Course
//Average Grade
