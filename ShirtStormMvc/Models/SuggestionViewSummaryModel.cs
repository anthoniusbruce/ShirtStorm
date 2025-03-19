using Microsoft.AspNetCore.Mvc;

namespace ShirtStormMvc.Models
{
    public class SuggestionSummaryViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        
        public required string Description { get; set; }

        public bool HasImage { get; set; }        
    }
}
