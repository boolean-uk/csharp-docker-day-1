using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataModels
{
    public class Doctor
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string FullName { get; set; }
        public List<Appointment> Appointments { get; set; } = [];
    }
}
