using exercise.wwwapi.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.ViewModels
{
    public class StudentPayload
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DoB { get; set; }

        public int CourseId { get; set; }

    }
}
