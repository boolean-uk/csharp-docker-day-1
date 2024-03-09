using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Xml;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime DOB { get; set; }


        // A student can attend many courses
        public ICollection<CourseStudent> CourseStudent { get; set; } = new List<CourseStudent>();

        [Column("average_grade")]
        public float AverageGrade { get; set; }
    }
}
