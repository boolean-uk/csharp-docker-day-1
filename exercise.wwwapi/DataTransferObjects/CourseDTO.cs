using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class CourseDTO
    {
        public DateOnly StartDateForCourse { get; set; }


        public string CourseTitle { get; set; }
    }
}
