using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DTO;

public class StudentPut
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    [Required]
    [MaxLength(255)]
    public required string Email { get; set; }
}