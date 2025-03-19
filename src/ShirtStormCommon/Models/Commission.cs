using System.ComponentModel.DataAnnotations;

namespace ShirtStormCommon.Models
{
    public class Commission
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string? Description { get; set; }
        public Guid? ImageId { get; set; }

    }
}
