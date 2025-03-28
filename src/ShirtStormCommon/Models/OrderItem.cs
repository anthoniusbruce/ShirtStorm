using System.ComponentModel.DataAnnotations;

namespace ShirtStormCommon.Models
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DesignId { get; set; }
        public Guid ShirtId { get; set; }
        public Guid AddressId { get; set; }
        public string? WnoFor { get; set; }
    }
}
