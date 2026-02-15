using System.ComponentModel.DataAnnotations;

namespace ShirtStormCommon.Models
{
    public class Design
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description {  get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool DisplayOnFrontPage {  get; set; } = false;
    }
}
