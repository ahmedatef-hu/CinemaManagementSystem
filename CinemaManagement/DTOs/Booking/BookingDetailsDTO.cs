namespace CinemaManagement.DTOs.Booking
{
    public class BookingDetailsDTO
    {
        public string CustomerName { get; set; }

        public string MovieTitle { get; set; }

        public string GenreName { get; set; }

        public DateTime BookingDate { get; set; }

        public int NumberOfTickets { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
