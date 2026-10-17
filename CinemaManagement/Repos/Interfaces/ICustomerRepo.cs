using CinemaManagement.Models;

namespace CinemaManagement.Repos.Interfaces
{
    public interface ICustomerRepo : IGenericRepo<Customer>
    {
        Task<List<Customer>> GetCustomersWithBookings();
        Task<List<Customer>> GetVipCustomers();
        Task<List<Customer>> GetCustomersWithoutBookings();
        Task<Customer?> GetCustomerWithBookings(int id);
    }
}
