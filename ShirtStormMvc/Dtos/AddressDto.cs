using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ShirtStormMvc.Dtos
{
    public class AddressDto
    {
        [HiddenInput]
        public Guid Id { get; set; }
        
        public string? Alias { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "(required)")]
        public required string Recipient { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "(required)")]
        public required string StreetAddress1 { get; set; }
        
        public string? StreetAddress2 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "(required)")]
        public required string CityStateZip { get; set; }
    }
}
