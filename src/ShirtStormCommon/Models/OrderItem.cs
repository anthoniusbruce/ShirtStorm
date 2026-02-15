using System.ComponentModel.DataAnnotations;

namespace ShirtStormCommon.Models
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid DesignId { get; set; }
        public Guid ShirtId { get; set; }
        public Guid AddressId { get; set; }
        public string? WhoFor { get; set; }
    }
}
