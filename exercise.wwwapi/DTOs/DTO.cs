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

        public List<StudentCourseDTO> CourseStudents { get; set; } = new List<StudentCourseDTO>();

        public float AverageGrade { get; set; }

        public StudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DOB = student.DOB;
            AverageGrade = student.AverageGrade;
            foreach (CourseStudent cs in student.CourseStudent)
            {
                CourseStudents.Add(new StudentCourseDTO(cs));
            }
        }
    }


    class StudentCourseDTO
    {
        public CourseDTO Course { get; set; }

        public StudentCourseDTO(CourseStudent cs)
        {
            Course = new CourseDTO(cs.Course);
        }
    }

    class CourseStudentDTO
    {
        public CourseDTO Course { get; set; }
        public StudentSingleDTO Student { get; set; }

        public CourseStudentDTO(CourseStudent courseStudent)
        { 
            Course = new CourseDTO(courseStudent.Course);
            Student = new StudentSingleDTO(courseStudent.Student);
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

        public List<SingleCourseStudentDTO> Students { get; set; } = new List<SingleCourseStudentDTO>();

        public CourseResponseDTO(Course course)
        {
            Id = course.Id;
            Title = course.Title;
            Teacher = course.Teacher;

            StartDate = course.StartDate;

            foreach (CourseStudent cs in course.CourseStudents)
            {
                Students.Add(new SingleCourseStudentDTO(cs));
            }
        }
    }


    class SingleCourseStudentDTO
    {

        public StudentSingleDTO Student { get; set; }

        public SingleCourseStudentDTO(CourseStudent cs)
        {
            Student = new StudentSingleDTO(cs.Student);
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
