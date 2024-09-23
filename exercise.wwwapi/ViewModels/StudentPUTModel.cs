using System.ComponentModel;

namespace exercise.wwwapi.ViewModels
{
    public class StudentPUTModel
    {
        [DefaultValue("")]
        public string FirstName { get; set; }
        [DefaultValue("")]
        public string LastName { get; set; }
        [DefaultValue("1900-01-01")]
        public DateTime DateOfBirth { get; set; } = new DateTime(1900, 1, 1).ToUniversalTime();
    }
}
