namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        public int Id { get; set; }

        public string courseName { get; set; }

        public DateTime courseDate { get; set; }

        public int averageGrade { get; set; }   

        public int studentId { get; set; }  
        public ICollection<Student>  student { get; set; }   


    }
}
