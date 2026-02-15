using System.ComponentModel.DataAnnotations;

namespace ShirtStormCommon.Models
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        public byte[] Bytes { get; set; } = [];
    }
}
