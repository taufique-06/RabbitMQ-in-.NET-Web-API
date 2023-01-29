using FormulaAirline.Model;
using FormulaAirline.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IMessageProducer _messageProducer;
        
        public static readonly List<Booking> bookings = new List<Booking>();
        public BookingController(ILogger<BookingController> logger, IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            if (!ModelState.IsValid) return BadRequest();
            bookings.Add(booking);
            _messageProducer.SendingMessages<Booking>(booking);
            return Ok();
        }
    }

}
