namespace ShirtStormMvc.Models
{
    public class CartViewModel
    {
        public required List<OrderItemSummaryViewModel> OrderItems { get; set; }
    }
}
