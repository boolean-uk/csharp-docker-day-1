using System.ComponentModel.DataAnnotations;

namespace exercise.wwwapi.DTOs
{
    public class CreateMovieDTO
    {


        [Required]
        public string Title { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int RunTimeMins { get; set; }
    }
}
