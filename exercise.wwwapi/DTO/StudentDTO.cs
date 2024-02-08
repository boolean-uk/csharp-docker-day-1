using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("date_of_birth")]
        public DateTimeOffset DoB { get; set; }

        [Column("average_grade")]
        public decimal AverageGrade { get; set; }

        public StudentDTO(Student student) {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            AverageGrade = student.AverageGrade;
            DoB = student.DoB;
        }
    }
}
