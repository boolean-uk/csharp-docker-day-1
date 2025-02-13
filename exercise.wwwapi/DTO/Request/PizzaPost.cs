using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace exercise.wwwapi.Models
{
    public class PizzaPost
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
