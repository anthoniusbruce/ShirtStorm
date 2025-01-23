using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Order
    {
        [Key]
        public Guid Id {  get; set; }
        [Required]
        public Guid UserId {  get; set; }
        [Required]
        public DesignUnit[]? DesignUnits {  get; set; }
    }
}
