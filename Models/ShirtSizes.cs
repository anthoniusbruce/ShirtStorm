using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class ShirtSizes
    {
        [Key]
        public Guid Id {  get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Model {  get; set; }
        [Required]
        public string? Size {  get; set; }
    }
}
