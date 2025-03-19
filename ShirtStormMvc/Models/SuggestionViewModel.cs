using Microsoft.AspNetCore.Mvc;

namespace ShirtStormMvc.Models
{
    public class SuggestionViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        
        public required string Description { get; set; }

        public string? ImageSource { get; set; }        
    }
}
