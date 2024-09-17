namespace exercise.wwwapi.DataModels
{
    public class Student
    {
        public int Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int courseId { get; set; }
        public Course course { get; set; }

       
        
    }
}
