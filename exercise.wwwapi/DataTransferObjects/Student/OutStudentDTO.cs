using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using exercise.wwwapi.DataTransferObjects.Course;

namespace exercise.wwwapi.DataTransferObjects.Student
{
    public class OutStudentDTO
    {
       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public double AverageGrade { get; set; }


        public OutCourseDTO Course { get; set; }
    }
}
