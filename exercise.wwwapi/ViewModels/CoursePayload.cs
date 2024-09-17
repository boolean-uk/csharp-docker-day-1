using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.ViewModels
{
    public class CoursePayload
    {
        public string Title { get; set; }

        public DateTime CourseStart { get; set; }

        public double AverageGrade { get; set; }
    }
}
