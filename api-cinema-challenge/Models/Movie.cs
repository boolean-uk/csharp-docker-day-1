﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_cinema_challenge.Models
{
    [Table("movies")]
    public class Movie : BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("rating")]
        public string Rating { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("runtime_mins")]
        public int RuntimeMins { get; set; }

        public List<Screening> Screenings { get; set; } = [];
    }
}
