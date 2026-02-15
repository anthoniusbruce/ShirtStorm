namespace ShirtStormMvc.Models
{
    public class ShirtViewModel
    {
        public Guid Id { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }
        public required string Size { get; set; }
    }
}
