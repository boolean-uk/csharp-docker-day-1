using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataModels
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
        public DateTime DateOfBirth { get; set; }

        [Column("fk_course")]
        [ForeignKey("Course")]
        [Required]
        public int course { get; set; }
    }
}
