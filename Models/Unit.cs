namespace ShirtStorm.Models
{
    public class Unit
    {
        [Required]
        public Guid? SizeId {  get; set; }
        [Required]
        public Guid? AddressId { get; set; }
    }
}
