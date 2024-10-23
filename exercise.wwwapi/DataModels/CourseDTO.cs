using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataModels
{
    public class CourseDTO
    {

        public int Id { get; set; }


        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public float AverageGrade { get; set; }
    }
}
