using AutoMapper;
using CinemaManagement.DTOs.Booking;
using CinemaManagement.UnitOFWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookingsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public bookingsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await unitOfWork.bookingRepo.GetAll();

            return Ok(mapper.Map<List<GetBookingDTO>>(bookings));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await unitOfWork.bookingRepo.GetById(id);

            if (booking == null)
                return NotFound();

            return Ok(mapper.Map<GetBookingDTO>(booking));
        }

        [HttpPost("book")]
        public async Task<IActionResult> Book(CreateBookingDTO dto)
        {
            var booking = await unitOfWork.bookingRepo.Createe(dto);

            if (booking == null)
                return BadRequest("Invalid customer, movie, or ticket quantity.");

            unitOfWork.Save();

            return Ok(mapper.Map<GetBookingDTO>(booking));
        }

        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var booking = await unitOfWork.bookingRepo.cancel(id);

            if (booking == null)
                return NotFound();

            unitOfWork.Save();

            return NoContent();
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetDetails()
        {
            var bookings = await unitOfWork.bookingRepo.GetBookingDetails();

            return Ok(bookings);
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenue()
        {
            var revenue = await unitOfWork.bookingRepo.GetRevenue();

            return Ok(revenue);
        }
    }
}
