using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        BookingService _bookingService;
        public BookingController(BookingService bookingService)
        {
            _bookingService=bookingService;
        }

        [HttpPost("AddBooking")]
        public IActionResult AddBooking(BookingModel bookingModel)
        {
            return Ok(_bookingService.AddBooking(bookingModel));    
        }
    }
}
