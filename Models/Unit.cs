using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Unit
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DesignUnitId { get; set; }
        public Guid SizeId {  get; set; }
        public Guid AddressId { get; set; }
    }
}
