using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO.Responses
{
    /// <summary>
    /// DTO for a Person
    /// </summary>
    public class PersonDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public OfficeDTO Office { get; set; }
        public List<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
    }
}
