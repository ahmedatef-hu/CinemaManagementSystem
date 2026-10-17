using CinemaManagement.Data;
using CinemaManagement.Repos.Interfaces;

namespace CinemaManagement.UnitOFWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IGenreRepo genreRepo { get; }
        public IMovieRepo movieRepo { get; }
        public ICustomerRepo customerRepo { get; }
        public IBookingRepo bookingRepo { get; }
        public UnitOfWork(AppDbContext context, IGenreRepo genreRepo, IMovieRepo movieRepo, ICustomerRepo customerRepo, IBookingRepo bookingRepo)
        {
            this.context = context;
            this.genreRepo = genreRepo;
            this.movieRepo = movieRepo;
            this.customerRepo = customerRepo;
            this.bookingRepo = bookingRepo;
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
