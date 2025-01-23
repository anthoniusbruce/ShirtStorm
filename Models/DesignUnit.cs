using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class DesignUnit
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DesignId { get; set; }
        public required Unit[] SizeDestination { get; set; }
    }
}
