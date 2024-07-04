using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Database.Entities
{
    public class Student : IdentityUser
    {
        [MaxLength(50)]
        public required string FirstName { get; set; }
        [MaxLength(50)]
        public required string LastName { get; set; }
        [MaxLength(15)]
        public required string NicNumber { get; set; }
        public string? ImageUrl { get; set; }
        public DateOnly DateOfBirth { get; set; }
        [MaxLength(400)]
        public string? Address { get; set; }
        public bool Sys_Deactivated { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
