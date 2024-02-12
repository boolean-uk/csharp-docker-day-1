using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.Models.Models
{
    [Table("students")]
    [PrimaryKey("Id")]
    public class Student
    {
        [Column("id")]
        [Required]
        public int Id { get; set; }
        [Column("first_name")]
        [Required]
        public string FirstName { get; set; } = "";
        [Column("last_name")]
        [Required]
        public string LastName { get; set; } = "";
        [Column("date_of_birth")]
        [Required]
        public DateOnly DateOfBirth { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
