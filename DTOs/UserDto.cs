using System.ComponentModel.DataAnnotations;

namespace Contact.DTOs
{
    public class UserDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public int CountContacts { get; set; } = 0;

    }
}
