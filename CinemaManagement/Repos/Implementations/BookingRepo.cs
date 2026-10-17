using CinemaManagement.Data;
using CinemaManagement.DTOs.Booking;
using CinemaManagement.Models;
using CinemaManagement.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Repos.Implementations
{
    public class BookingRepo : GenericRepo<Booking>, IBookingRepo
    {
        public BookingRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<Booking> cancel(int id)
        {
            var booking = await context.Bookings
                .Include(b => b.Movie)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null)
                return null;

            booking.Movie.AvailableSeats += booking.NumberOfTickets;
            context.Bookings.Update(booking);

            return booking;
        }

        public async Task<Booking> Createe(CreateBookingDTO dto)
        {
            var customer = await context.Customers
                .FindAsync(dto.CustomerId);

            var movie = await context.Movies
                .FindAsync (dto.MovieId);

            if(customer == null)
            {
                return null;
            }
            if(movie == null)
            {
                return null;
            }

            if(dto.NumberOfTickets < 0 || dto.NumberOfTickets > movie.AvailableSeats)
            {
                return null;
            }

            var booking = new Booking
            {
                BookingDate = DateTime.Now,
                CustomerId = dto.CustomerId,
                MovieId = dto.MovieId,
                NumberOfTickets = dto.NumberOfTickets,
                TotalPrice = movie.AvailableSeats * dto.NumberOfTickets
            };
            movie.AvailableSeats -= dto.NumberOfTickets;
            context.Bookings.Add(booking);
            return booking;

        }

        public async Task<List<BookingDetailsDTO>> GetBookingDetails()
        {
            return await context.Bookings
            .Select(b => new BookingDetailsDTO
            {
                CustomerName = b.Customer.FullName,
                MovieTitle = b.Movie.Title,
                GenreName = b.Movie.Genre.Name,
                BookingDate = b.BookingDate,
                NumberOfTickets = b.NumberOfTickets,
                TotalPrice = b.TotalPrice
            })
            .ToListAsync();
        }

        public async Task<List<RevenueDTO>> GetRevenue()
        {
            return await context.Movies
            .Select(m => new RevenueDTO
            {
                MovieTitle = m.Title,
                TotalTicketsSold = m.Bookings.Sum(b => b.NumberOfTickets),
                TotalRevenue = m.Bookings.Sum(b => b.TotalPrice)
            })
            .OrderByDescending(r => r.TotalRevenue)
            .ToListAsync();
        }

    }
}
