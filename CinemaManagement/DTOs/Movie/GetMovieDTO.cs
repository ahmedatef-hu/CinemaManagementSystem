using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.DTOs.Movie
{
    public class GetMovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public decimal TicketPrice { get; set; }
        public int AvailableSeats { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
