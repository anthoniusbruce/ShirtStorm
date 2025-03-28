using System.ComponentModel.DataAnnotations;

namespace ShirtStormCommon.Models
{
    public class Order
    {
        [Key]
        public Guid Id {  get; set; }
        public Guid CustomerId {  get; set; }
        public OrderItems[] OrderItems { get; set; } = [];
    }
}
