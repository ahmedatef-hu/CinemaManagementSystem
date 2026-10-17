using CinemaManagement.DTOs.Booking;
using CinemaManagement.Models;

namespace CinemaManagement.Repos.Interfaces
{
    public interface IBookingRepo : IGenericRepo<Booking>
    {
        Task<Booking> Createe(CreateBookingDTO dto);
        Task<Booking> cancel(int id);
        //Task<Booking> GetBookingWithMovie(int id);

        Task<List<BookingDetailsDTO>> GetBookingDetails();

        Task<List<RevenueDTO>> GetRevenue();
    }
}
