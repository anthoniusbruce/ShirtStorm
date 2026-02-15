
namespace ShirtStormMvc.Models
{
    public class OrderItemViewModel
    {
        public Guid Id { get; set; }
        public Guid ShirtId { get; set; }
        public Guid AddressId { get; set; }
        public string? WhoFor {  get; set; }
    }
}
