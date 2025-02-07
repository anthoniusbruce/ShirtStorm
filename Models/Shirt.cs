using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Shirt
    {
        [Key]
        public Guid Id { get; set; }
        public string? Brand {  get; set; }
        public string? Model {  get; set; }
        public Guid SizeId { get; set; }
    }
}
