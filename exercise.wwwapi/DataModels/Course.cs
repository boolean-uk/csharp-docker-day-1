﻿using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("couses")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("course_title")]
        public string CourseTitle { get; set; }
        [Column("course_start_date")]
        public DateTime CourseStartDate { get; set; }
        [Column("average_grade")]
        public float AverageGrade { get; set; }
    }
}
