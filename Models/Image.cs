using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        public required byte[] Bytes { get; set; }
    }
}
