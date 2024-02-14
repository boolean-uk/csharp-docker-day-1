using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    public class StudentPost
    {

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

      
        public DateTime Date_Of_Birth { get; set; }


        public int CourseId { get; set; }


        public float Average_Grade { get; set; }
    }
}
