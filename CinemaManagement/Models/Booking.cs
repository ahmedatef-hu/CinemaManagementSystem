using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Range(1, int.MaxValue)]
        public int NumberOfTickets { get; set; }
        [Range(0, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
    }
}
