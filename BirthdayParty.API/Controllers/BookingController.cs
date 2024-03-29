using BirthdayParty.Models;
using BirthdayParty.Models.Converters;
using BirthdayParty.Models.DTOs;
using BirthdayParty.Repository.Interfaces;
using BirthdayParty.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace BirthdayParty.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IServiceService _serviceService;
        private readonly IGenericRepository<BookingService> _bookingServiceService;

        public BookingController(IBookingService bookingService, IServiceService serviceService
                , IGenericRepository<BookingService> bookingServiceService) {
            _bookingService = bookingService;
            _serviceService = serviceService;
            _bookingServiceService = bookingServiceService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Booking>>> GetAll()
        {
            List<Booking> bookings = _bookingService.GetAllBookings();

            return Ok(bookings);
        }

        [HttpGet("GetAllByUserId")]
        public async Task<ActionResult<List<Booking>>> GetAllByUserId(int id)
        {
            List<Booking> bookings = _bookingService.GetAllBookings().Where(b => b.UserId == id).ToList();

            return Ok(bookings);
        }

        [HttpGet("GetAllOngoingByUserId")]
        public async Task<ActionResult<List<Booking>>> GetAllOngoingByUserId(int id)
        {
            List<Booking> bookings = _bookingService.GetAllBookings()
                .Where(b => b.UserId == id &&
                        b.BookingStatus == "Accepted" &&
                        b.PartyDateTime > DateTime.Now).ToList();

            return Ok(bookings);
        }

        [HttpGet("GetAllPending")]
        public async Task<ActionResult<List<Booking>>> GetAllPendingBookings()
        {
            List<Booking> bookings = _bookingService.GetAllBookings().Where(b => b.BookingStatus == "Pending").ToList();

            return Ok(bookings);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Booking>> Create([FromBody] BookingDTO bookingDTO)
        {
            var book = _bookingService.CreateBooking(bookingDTO);

            foreach(var serviceId in bookingDTO.ServiceIds)
            {
                var bookingService = new BookingService{
                    BookingId = book.BookingId,
                    ServiceId = serviceId,
                };
                _bookingServiceService.Add(bookingService);
            }

            return Ok(book);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Booking>> UpdateBooking([FromBody] BookingDTO bookingDTO)
        {
            foreach(var serviceId in bookingDTO.ServiceIds)
            {
                var bookingService = new BookingService{
                    BookingId = bookingDTO.BookingId.Value,
                    ServiceId = serviceId,
                };
                _bookingServiceService.Update(bookingService);
            }

            var book = _bookingService.UpdateBooking(bookingDTO);

            return Ok(book);
         
        }

        [HttpPut("UpdateStatus")]
        public async Task<ActionResult<Booking>> UpdateStatus([FromBody] UpdateBookingStatusDTO statusDTO)
        {
            var booking = _bookingService.GetBooking(statusDTO.BookingId);

            var bookingDTO = new BookingDTO{
                BookingId = booking.BookingId,
                UserId = booking.UserId,
                RoomId = booking.RoomId,
                PartyDateTime = booking.PartyDateTime,
                BookingStatus= statusDTO.Status,
                Feedback = booking.Feedback,
            };

            var book = _bookingService.UpdateBooking(bookingDTO);

            return Ok(book);
         
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Booking>> DeleteBooking([FromBody] int id)
        {
            var bookingServices = _bookingServiceService.GetAll().Where(b => b.BookingId == id);

            foreach(var bookingService in bookingServices)
            {
                _bookingServiceService.Delete(bookingService.BookingServiceId);
            }

            Booking booking = _bookingService.DeleteBooking(id);

            return Ok(booking);
        }

    }

    public class UpdateBookingStatusDTO
    {
        public int BookingId { get; set; }
        public string Status { get; set; } = null!;
    }
}
