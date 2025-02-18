using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Order
    {
        [Key]
        public Guid Id {  get; set; }
        public Guid UserId {  get; set; }
        public DesignUnit[] DesignUnits { get; set; } = [];
    }
}
