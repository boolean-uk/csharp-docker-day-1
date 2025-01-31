using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DTOs
{
    public class CreateCustomerDTO
    {


        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
