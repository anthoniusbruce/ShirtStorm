using Microsoft.AspNetCore.Mvc;

namespace ShirtStormMvc.Models
{
    public class AddressViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        
        public string? Alias { get; set; }
        
        public required string Recipient { get; set; }
        
        public required string StreetAddress1 { get; set; }
        
        public string? StreetAddress2 { get; set; }

        public required string CityStateZip { get; set; }
    }
}
