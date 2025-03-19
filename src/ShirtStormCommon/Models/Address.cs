using System.ComponentModel.DataAnnotations;

namespace ShirtStormCommon.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        public Guid CustomerGuid { get; set; }
        public string? Recipient { get; set; }
        public string? StreetAddress1 { get; set; }
        public string? StreetAddress2 { get; set; }
        public string? CityStateZip { get; set; }
        public string? Alias { get; set; }
    }
}
