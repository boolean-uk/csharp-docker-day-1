using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DTO;

public class CoursePut
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    [Required]
    [Range(1, 30)]
    public int Credits { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Department { get; set; }
}