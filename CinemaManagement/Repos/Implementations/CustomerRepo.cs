using CinemaManagement.Data;
using CinemaManagement.Models;
using CinemaManagement.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaManagement.Repos.Implementations
{
    public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
    {
        public CustomerRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetCustomersWithBookings()
        {
            return await context.Customers
            .Include(c => c.Bookings)
            .ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersWithoutBookings()
        {
            return await context.Customers
            .Where(c => !c.Bookings.Any())
            .ToListAsync();
        }

        public async Task<List<Customer>> GetVipCustomers()
        {
            return await context.Customers
            .OrderByDescending(c => c.Bookings.Sum(b => b.TotalPrice))
            .ToListAsync();
        }
        public async Task<Customer?> GetCustomerWithBookings(int id)
        {
            return await context.Customers
                .Include(c => c.Bookings)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
