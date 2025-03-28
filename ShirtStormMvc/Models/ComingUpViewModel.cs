namespace ShirtStormMvc.Models
{
    public class ComingUpViewModel
    {
        public required FrontPageDesignViewModel Design { get; set; }
        public required Guid DesignId { get; set; }
        public int OrderTotal { get; set; }
    }
}
