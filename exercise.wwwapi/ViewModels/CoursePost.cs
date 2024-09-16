using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.ViewModels
{
    public class CoursePost
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string StartDate { get; set; }
    }
}
