using System.ComponentModel.DataAnnotations;

namespace ShirtStorm.Models
{
    public class Design
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
        public required string Title { get; set; }
        public required string Description {  get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool DisplayOnFrontPage {  get; set; }
    }
}
