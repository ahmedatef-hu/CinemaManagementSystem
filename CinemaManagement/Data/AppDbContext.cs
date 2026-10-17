using CinemaManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Movie>()
                .HasIndex(c => c.Title)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Booking>()
                .Property(c => c.BookingDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Movie>()
                .Property(c => c.TicketPrice)
                .HasPrecision(10, 2);


            modelBuilder.Entity<Genre>()
                .HasMany(c => c.Movies)
                .WithOne(c => c.Genre)
                .HasForeignKey(c => c.GenreId);


            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Bookings)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);


            modelBuilder.Entity<Movie>()
                .HasMany(c => c.Bookings)
                .WithOne(c => c.Movie)
                .HasForeignKey(c => c.MovieId);



            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Comedy" },
                new Genre { Id = 3, Name = "Horror" },
                new Genre { Id = 4, Name = "Drama" },
                new Genre { Id = 5, Name = "Sci-Fi" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", Director = "Christopher Nolan", Duration = 148, ReleaseYear = 2010, Rating = 8.8, TicketPrice = 100, AvailableSeats = 50, GenreId = 1 },
                new Movie { Id = 2, Title = "The Dark Knight", Director = "Christopher Nolan", Duration = 152, ReleaseYear = 2008, Rating = 9.0, TicketPrice = 120, AvailableSeats = 40, GenreId = 1 },
                new Movie { Id = 3, Title = "The Mask", Director = "Chuck Russell", Duration = 101, ReleaseYear = 1994, Rating = 6.9, TicketPrice = 80, AvailableSeats = 60, GenreId = 2 },
                new Movie { Id = 4, Title = "Interstellar", Director = "Christopher Nolan", Duration = 169, ReleaseYear = 2014, Rating = 8.7, TicketPrice = 150, AvailableSeats = 35, GenreId = 5 },
                new Movie { Id = 5, Title = "The Conjuring", Director = "James Wan", Duration = 112, ReleaseYear = 2013, Rating = 7.5, TicketPrice = 90, AvailableSeats = 45, GenreId = 3 },
                new Movie { Id = 6, Title = "Titanic", Director = "James Cameron", Duration = 195, ReleaseYear = 1997, Rating = 7.9, TicketPrice = 110, AvailableSeats = 55, GenreId = 4 }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FullName = "Ahmed Ali", Email = "ahmed@example.com", PhoneNumber = "01012345678" },
                new Customer { Id = 2, FullName = "Omar Hassan", Email = "omar@example.com", PhoneNumber = "01112345678" },
                new Customer { Id = 3, FullName = "Mariam Mohamed", Email = "mariam@example.com", PhoneNumber = "01212345678" },
                new Customer { Id = 4, FullName = "Youssef Adel", Email = "youssef@example.com", PhoneNumber = "01098765432" },
                new Customer { Id = 5, FullName = "Sara Mahmoud", Email = "sara@example.com", PhoneNumber = "01198765432" }
            );


            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, CustomerId = 1, MovieId = 1, BookingDate = new DateTime(2026, 10, 1), NumberOfTickets = 2, TotalPrice = 200 },
                new Booking { Id = 2, CustomerId = 2, MovieId = 2, BookingDate = new DateTime(2026, 10, 2), NumberOfTickets = 3, TotalPrice = 360 },
                new Booking { Id = 3, CustomerId = 3, MovieId = 3, BookingDate = new DateTime(2026, 10, 3), NumberOfTickets = 1, TotalPrice = 80 },
                new Booking { Id = 4, CustomerId = 1, MovieId = 4, BookingDate = new DateTime(2026, 10, 4), NumberOfTickets = 2, TotalPrice = 300 },
                new Booking { Id = 5, CustomerId = 4, MovieId = 5, BookingDate = new DateTime(2026, 10, 5), NumberOfTickets = 4, TotalPrice = 360 },
                new Booking { Id = 6, CustomerId = 5, MovieId = 1, BookingDate = new DateTime(2026, 10, 6), NumberOfTickets = 1, TotalPrice = 100 }
            );
        }
    }
}
