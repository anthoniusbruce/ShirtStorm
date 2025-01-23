using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class DesignUnit
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid DesignId { get; set; }
        [Required]
        public Unit[]? SizeDestination { get; set; }
    }
}
