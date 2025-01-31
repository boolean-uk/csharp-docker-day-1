﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.Models
{
    [Table("movie_table")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("movie_title")]
        public string Title { get; set; }

        [Column("rating")]
        public string Rating { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("runtime_mins")]
        public int RunTimeMins { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
