using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DTO;

public class CoursePost
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [Range(1, 30)]
    public int Credits { get; set; }
    [Required]
    [MaxLength(100)]
    public string Department { get; set; }
}