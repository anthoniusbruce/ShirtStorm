
namespace ShirtStormMvc.Models
{
    public class OrderItemSummaryViewModel
    {
        public Guid Id { get; set; }
        public Guid DesignId { get; set; }
        public string? Size { get; set; }
        public string? AddressAlias { get; set; }
        public string? WhoFor {  get; set; }
    }
}
