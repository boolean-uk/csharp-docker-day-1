
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    
    public class Course
    {    
        public int Id { get; set; }
        public string Title { get; set; }
        public List<CoursePerson> CoursePersons { get; set; } = [];
        public List<Person> People { get; set; } = [];
    }
}
