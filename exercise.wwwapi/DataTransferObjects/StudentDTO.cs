using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }

        public Course Course { get; set; }

        public StudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;    
            DoB = student.DoB;
            Course = student.Course;
        }

    }
}
