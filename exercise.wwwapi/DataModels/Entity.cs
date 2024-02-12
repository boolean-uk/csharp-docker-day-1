using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    public abstract class Entity
    {
        [Column("id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Column("created_at"), DataType("date")]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at"), DataType("date")]
        public DateTime UpdatedAt { get; set; }
    }
}
