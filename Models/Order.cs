using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Order
    {
        [Key]
        public Guid Id {  get; set; }
        public Guid UserId {  get; set; }
        public required DesignUnit[] DesignUnits {  get; set; }
    }
}
