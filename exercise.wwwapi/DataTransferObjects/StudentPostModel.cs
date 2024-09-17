using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataTransferObjects
{
    public class StudentPostModel
    {
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public int DateOfBirth { get; set; }
      
        public int CourseId { get; set; }

        public decimal AvgGrade { get; set; }
    }
}
