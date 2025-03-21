using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ShirtStormMvc.Models
{
    public class CommissionViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }
        
        public required string Description { get; set; }

        [HiddenInput]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public required DateTime CreatedDate {  get; set; }
    }
}
