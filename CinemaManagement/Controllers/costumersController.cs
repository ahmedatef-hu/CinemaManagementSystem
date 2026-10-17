using AutoMapper;
using CinemaManagement.DTOs.Customer;
using CinemaManagement.Models;
using CinemaManagement.UnitOFWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class costumersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public costumersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await unitOfWork.customerRepo.GetAll();

            var result = mapper.Map<List<GetCustomerDTO>>(customers);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await unitOfWork.customerRepo.GetById(id);

            if (customer == null)
                return NotFound();

            var result = mapper.Map<GetCustomerDTO>(customer);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDTO dto)
        {
            var customer = mapper.Map<Customer>(dto);

            await unitOfWork.customerRepo.Create(customer);
            unitOfWork.Save();

            var result = mapper.Map<GetCustomerDTO>(customer);

            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateCustomerDTO dto)
        {
            var customer = await unitOfWork.customerRepo.GetById(id);

            if (customer == null)
                return NotFound();

            mapper.Map(dto, customer);

            unitOfWork.customerRepo.Update(customer);
            unitOfWork.Save();

            return Ok(mapper.Map<GetCustomerDTO>(customer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await unitOfWork.customerRepo.GetCustomerWithBookings(id);

            if (customer.Bookings.Any())
                return BadRequest();

            await unitOfWork.customerRepo.Delete(customer);
            unitOfWork.Save();

            return NoContent();
        }

        [HttpGet("bookings")]
        public async Task<IActionResult> GetCustomersWithBookings()
        {
            var customers = await unitOfWork.customerRepo.GetCustomersWithBookings();

            return Ok(mapper.Map<List<GetCustomerDTO>>(customers));
        }

        [HttpGet("vip")]
        public async Task<IActionResult> GetVipCustomers()
        {
            var customers = await unitOfWork.customerRepo.GetVipCustomers();

            return Ok(mapper.Map<List<GetCustomerDTO>>(customers));
        }

        [HttpGet("no-bookings")]
        public async Task<IActionResult> GetCustomersWithoutBookings()
        {
            var customers = await unitOfWork.customerRepo.GetCustomersWithoutBookings();

            return Ok(mapper.Map<List<GetCustomerDTO>>(customers));
        }
    }
}
