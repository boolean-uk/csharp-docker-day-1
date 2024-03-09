using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Xml;

namespace exercise.wwwapi.DataModels
{
    public class CourseStudent
    {

        [Column("course_id")]
        public int CourseId { get; set; }
        public Course Course { get; set; }


        [Column("student_id")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
