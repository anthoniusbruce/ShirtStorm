using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class ShirtSizes
    {
        [Key]
        public Guid Id {  get; set; }
        public string? Brand { get; set; }
        public string? Model {  get; set; }
        public string? Size {  get; set; }
    }
}
