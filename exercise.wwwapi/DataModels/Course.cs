using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("courses")]
    public class Course
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public Course Update (CourseDto course)
        {
            this.Title = course.Title;
            this.StartDate = course.StartDate;
            return this;
        }

        public CourseDto ToDto()
        {
            return new CourseDto { Title = this.Title, StartDate = this.StartDate };
        }
    }

    public class CourseDto
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
    }
}
