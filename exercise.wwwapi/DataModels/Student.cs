using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using exercise.wwwapi.Interfaces;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    [PrimaryKey("Id")]
    public class Student : IStudent
    {
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [Column("first_name")]
        [Required]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        public string LastName { get; set; }

        [Column("date_of_birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Column("fk_course_id")]
        [ForeignKey("Course")]
        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
