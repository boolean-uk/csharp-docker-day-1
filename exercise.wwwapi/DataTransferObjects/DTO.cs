using exercise.wwwapi.DataModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;


namespace exercise.wwwapi.DataTransferObjects
{
    class StudentResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int avgGrade { get; set; }

        public List<StudentEnrollmentDTO> Enrollments { get; set; } = new List<StudentEnrollmentDTO>();

        public StudentResponseDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DateOfBirth = student.DateOfBirth;
            avgGrade = student.AvgGrade;
        }
    }

    class CourseResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly StartDate { get; set; }

        public List<CourseEnrollmentDTO> Enrollments { get; set; } = new List<CourseEnrollmentDTO>();

        public CourseResponseDTO(Course course)
        {
            Id = course.Id;
            Title = course.CourseTitle;
            StartDate = course.StartDate;
        }
    }

    class StudentEnrollmentDTO
    {
        public DateOnly StartDate { get; set; }
        public string CourseTitle { get; set; }
        public CourseDTO Course { get; set; }

        public StudentEnrollmentDTO(Enrollments enrollment)
        {
            StartDate = enrollment.StartDate;
            CourseTitle = enrollment.Title;
            Course = new CourseDTO(enrollment.Course);
        }
    }

    class CourseEnrollmentDTO
    {
        public DateOnly StartDate { get; set; }
        public string Title { get; set; }

        public StudentDTO Student { get; set; }

        public CourseEnrollmentDTO(Enrollments enrollment)
        {
            StartDate = enrollment.StartDate;
            Student = new StudentDTO(enrollment.Student);
        }
    }
    class EnrollmentDTO
    {
        public DateOnly StartDate { get; set; }
        public string Title { get; set; }

        public StudentDTO Student { get; set; }
        public CourseDTO Course { get; set; }

        public EnrollmentDTO(Enrollments enrollment)
        {
            StartDate = enrollment.StartDate;
            Title = enrollment.Title;
            Student = new StudentDTO(enrollment.Student);
            Course = new CourseDTO(enrollment.Course);
        }
    }

    class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly StartDate { get; set; }

        public CourseDTO(Course course)
        {
            Id = course.Id;
            StartDate = course.StartDate;
            Title = course.CourseTitle;
        }
    }

    class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public StudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
        }
    }


}
