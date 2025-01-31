namespace exercise.wwwapi.DTOs.response
{
    public class OrderToppingDTO
    {
        public int OrderId { get; set; }
        public int ToppingId { get; set; }
        public ToppingDTO Topping { get; set; }
    }
}
