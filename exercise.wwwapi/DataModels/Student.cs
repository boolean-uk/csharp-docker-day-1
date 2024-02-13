﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id"), JsonIgnore]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("date_of_birth")]
        public DateOnly DateOfBirth { get; set; }
        [Column("course_title")]
        public string CourseTitle { get; set; }
        [Column("course_start_date")]
        public DateOnly CourseStartDate { get; set; }
        [Column("average_grade")]
        public float AverageGrade { get; set; }
    }
}
