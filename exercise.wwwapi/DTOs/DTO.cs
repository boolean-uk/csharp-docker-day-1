using exercise.wwwapi.DataModels;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace exercise.wwwapi.DTOs
{
    class StudentDTO
    {
        public int Id { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public int CourseId { get; set; }
    
        public float AverageGrade { get; set; }

        public StudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DOB = student.DOB;
            CourseId = student.CourseId;
            AverageGrade = student.AverageGrade;
        }
    }


    class CourseResponseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public DateTime StartDate { get; set; }

        public List<StudentDTO> Students { get; set; } = new List<StudentDTO>();

        public CourseResponseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;

            StartDate = course.StartDate;

            foreach (Student student in course.Students)
            {
              Students.Add(new StudentDTO(student));
           }
        }
    }
}
