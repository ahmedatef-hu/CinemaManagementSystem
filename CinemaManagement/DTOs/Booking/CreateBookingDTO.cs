using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.DTOs.Booking
{
    public class CreateBookingDTO
    {
        [Required]
        public DateTime BookingDate { get; set; }
        [Range(1, int.MaxValue)]
        public int NumberOfTickets { get; set; }
        [Range(0, double.MaxValue)]
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
    }
}
