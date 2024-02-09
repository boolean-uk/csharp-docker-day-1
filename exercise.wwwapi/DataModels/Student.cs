using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("date_of_birth")]
        public string DateOfBirth { get; set; }
        public ICollection<Registration> Registrations { get; set; }
    }

    public record StudentPayload(string firstName, string lastName, string dateOfBirth);
}
