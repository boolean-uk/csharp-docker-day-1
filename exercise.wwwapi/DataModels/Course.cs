using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course

    { 
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title   { get; set; }

        [Column("start")]
        public DateOnly StartsAt { get; set; }

      
    }
}
