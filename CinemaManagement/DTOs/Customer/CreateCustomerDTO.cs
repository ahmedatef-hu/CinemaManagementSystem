using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.DTOs.Customer
{
    public class CreateCustomerDTO
    {
        [Required, MaxLength(150)]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }

    }
}
