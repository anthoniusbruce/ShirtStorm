using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? Recipient { get; set; }
        [Required]
        public string? StreetAddress { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? ZipCode { get; set; }
    }
}
