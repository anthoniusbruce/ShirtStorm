using System.ComponentModel.DataAnnotations;

namespace ShirtStormCommon.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        public required string IdentityEmail { get; set; }
        public required string FirstName { get; set; }
        public required string Surname { get; set; }
        public required string DisplayName { get; set; }

        public bool IsAMember { get; set; }
    }
}
