using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;

        [Column("course_id")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Column("average_grade")]
        public float AverageGrade { get; set; }

        public Student Update (StudentInput student)
        {
            this.FirstName = student.FirstName;
            this.LastName = student.LastName;
            this.DateOfBirth = student.DateOfBirth;
            this.CourseId = student.CourseId;
            this.AverageGrade = student.AverageGrade;
            return this;
        }

        public StudentDto ToDto()
        {
            return new StudentDto { 
                Id = this.Id, 
                FirstName = this.FirstName, 
                LastName = this.LastName, 
                DateOfBirth = this.DateOfBirth, 
                AverageGrade = this.AverageGrade, 
                Course = this.Course.ToDto() 
            };
        }
    }

    public class StudentInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CourseId { get; set; }
        public float AverageGrade { get; set; }
    }

    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float AverageGrade { get; set; }
        public CourseDto Course { get; set; }
    }
}
