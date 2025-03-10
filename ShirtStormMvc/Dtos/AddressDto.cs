namespace ShirtStormMvc.Dtos
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public required string Alias { get; set; }
        public required string Recipient { get; set; }
        public required string StreetAddress1 { get; set; }
        public string? StreetAddress2 { get; set; }
        public required string CityStateZip { get; set; }
    }
}
