using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class ShirtSizes
    {
        [Key]
        public Guid Id {  get; set; }
        public required string Brand { get; set; }
        public required string Model {  get; set; }
        public required string Size {  get; set; }
    }
}
