namespace workshop.wwwapi.Models
{
    public class CoursePerson
    {        
        //public int Id { get; set; }
        public int CourseId { get; set; }
        public int PersonId { get; set; }
        public Course Course { get; set; }
        public Person Person { get; set; }
    }
}
