using System.ComponentModel.DataAnnotations;

namespace ShirtStormCommon.Models
{
    public class Suggestion
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CustomerGuid { get; set; }
        public string? Description { get; set; }
    }
}
