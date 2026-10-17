using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.DTOs.Customer
{
    public class GetCustomerDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
