using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        public int Id { get; set; }

        [Column("Course_Title")]
        public string Course_Title { get; set; }

        [Column("Start_Date_For_Course")]
        public DateTime Start_Date_For_Course { get; set; }

   

    }
}
