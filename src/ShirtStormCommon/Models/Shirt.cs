using System.ComponentModel.DataAnnotations;

namespace ShirtStormCommon.Models
{
    public class Shirt
    {
        [Key]
        public Guid Id {  get; set; }
        public string? Brand { get; set; }
        public string? Model {  get; set; }
        public string? Size {  get; set; }
    }
}
