using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("tickets")]
    public class Ticket
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("screening_id")]
        [ForeignKey("screenings")]
        public int ScreeningId { get; set; }

        [Column("customer_id")]
        [ForeignKey("customers")]
        public int CustomerId { get; set; }

        [Column("numSeats")]
        public int NumSeats { get; set; }

        [Column("created_at", TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at", TypeName = "timestamp")]
        public DateTime UpdatedAt { get; set; }

        public Screening Screening { get; set; }
        public Customer Customer { get; set; }

    }
}
