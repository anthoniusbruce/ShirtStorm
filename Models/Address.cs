using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public required string Recipient { get; set; }
        public required string StreetAddress { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
    }
}
