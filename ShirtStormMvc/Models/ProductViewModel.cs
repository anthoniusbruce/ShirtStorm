namespace ShirtStormMvc.Models
{
    public class ProductViewModel
    {
        public required FrontPageDesignViewModel Design { get; set; }
        public required Guid DesignId { get; set; }
        public int OrderTotal { get; set; }
    }
}
