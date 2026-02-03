using System.ComponentModel.DataAnnotations;

namespace TaskManager.DTOs.Users
{
    public class UpdateUserDto
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
