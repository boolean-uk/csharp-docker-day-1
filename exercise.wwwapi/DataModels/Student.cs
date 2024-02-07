using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.DataModels
{
    [Table("students")]
    public class Student
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("date_of_birth")]
        public string DateOfBirth { get; set; }

        //[Column("course_id")]
        //public int CourseId {  get; set; } // when we have a list, this will no longer be needed. remember to change  the data context file as well as the repository.

        
        //public Course Course { get; set;} //make this a list/dictionary/ienumerabel later 
        public List<Course> Courses { get; set;}

        public Student()
        {
            Courses = new List<Course>();
        }
    }
}
