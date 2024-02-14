﻿using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

    }
}
