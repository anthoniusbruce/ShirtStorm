using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public byte[]? Bytes { get; set; }
    }
}
