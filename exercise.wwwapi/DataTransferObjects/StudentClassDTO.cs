using System;
using exercise.wwwapi.DataModels;

namespace exercise.wwwapi.DataModels
{
    public class StudentClassDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float AverageGrade { get; set; }
        public CourseForStudentDTO Course { get; set; }

        public StudentClassDTO(Student student)
        {


            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            DateOfBirth = student.DateOfBirth;
            AverageGrade = student.AvarageGrade;
            Course = new CourseForStudentDTO(student.Course);
        }
        public static List<StudentClassDTO> FromListOfStudents(List<Student> students)
        {


            return students.Select(student => new StudentClassDTO(student)).ToList();
        }
    }

    public class CourseForStudentDTO
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string TutorName { get; set; }
        public DateTime StartDate { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }


        public CourseForStudentDTO(Course course)
        {


            Id = course.Id;
            CourseName = course.CourseName;
            TutorName = course.TutorName;
            StartDate = course.StartDate;
            Capacity = course.Capacity;
            Location = course.Location;
        }
    }
}
