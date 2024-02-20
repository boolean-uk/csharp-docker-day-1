using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("student")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
        [Column("birthdate")]
        public DateTime DateOfBirth { get; set; }
        
        [Column("course_id")]
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        
    }
}
