using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataTransferObjects.StudentCourse
{
    public class AddStudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public float AvgGrade { get; set; }
    }
}
