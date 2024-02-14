using System.ComponentModel.DataAnnotations.Schema;
using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public string CourseTitle { get; set; }
        public DateTimeOffset StartDate { get; set; }

        public int AvgGrade { get; set; }
        public int CourseId { get; set; }

        public StudentDto(Student student) 
        { 
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            BirthDate = student.BirthDate;
            CourseTitle = student.CourseTitle;
            StartDate = student.StartDate;
            AvgGrade = student.AvgGrade;
            CourseId = student.CourseId;
        } 
    }
}
