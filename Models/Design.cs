using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Design
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid? ImageId { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description {  get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public bool DisplayOnFrontPage {  get; set; }
    }
}
