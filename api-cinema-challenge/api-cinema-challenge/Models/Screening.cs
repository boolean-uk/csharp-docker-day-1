﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("screening")]
    public class Screening
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("screen_number")]
        public int ScreenNumber { get; set; }

        [Column("capasity")]
        public int Capasity { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("starts_at")]
        public DateTime StartsAt { get; set; }

        [ForeignKey(nameof(Movie))]
        [Column("movie_id")]
        public int MovieId { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
        
    }
}
