using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public string? Recipient { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
