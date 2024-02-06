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

        public CourseDTO Course { get; set; }

        public float AverageGrade { get; set; }

        public StudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DOB = student.DOB;
            Course = new CourseDTO(student.Course);
            AverageGrade = student.AverageGrade;
        }
    }


    class StudentSingleDTO
    {
        public int Id { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public float AverageGrade { get; set; }

        public StudentSingleDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DOB = student.DOB;
            AverageGrade = student.AverageGrade;
        }
    }

    class CourseResponseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Teacher { get; set; }
        public DateTime StartDate { get; set; }

        public List<StudentSingleDTO> Students { get; set; } = new List<StudentSingleDTO>();

        public CourseResponseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            Teacher = course.Teacher;

            StartDate = course.StartDate;

            foreach (Student student in course.Students)
            {
              Students.Add(new StudentSingleDTO(student));
           }
        }
    }


    class CourseDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Teacher { get; set; }
        public DateTime StartDate { get; set; }

        public CourseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            Teacher = course.Teacher;

            StartDate = course.StartDate;
        }
    }
}
