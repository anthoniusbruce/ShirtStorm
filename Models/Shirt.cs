using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Shirt
    {
        [Key]
        public Guid Id { get; set; }
        public required string Brand {  get; set; }
        public required string Model {  get; set; }
        public Guid SizeId { get; set; }
    }
}
