using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Xml;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("Course")]
        [Column("course_id")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [Column("course_date")]
        public DateTime CourseDate { get; set; }
        [Column("average_grade")]
        [Range(0, 10)]
        public double AverageGrade { get; set; }

        public object DtObject()
        {
            if (Course != null) {return new
            {
                Id,
                FirstName,
                LastName,
                DateOfBirth,
                CourseId,
                CourseTitle = Course.Title,
                CourseDate,
                AverageGrade
            };
            }
            else {
                return new
                {
                    Id,
                    FirstName,
                    LastName,
                    DateOfBirth,
                    CourseId,
                    CourseDate,
                    AverageGrade
                };
            }
            
        }

    }
    
    
        
    
}
