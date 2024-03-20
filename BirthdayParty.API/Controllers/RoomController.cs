using BirthdayParty.Models;
using BirthdayParty.Models.DTOs;
using BirthdayParty.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;

        public RoomController(IRoomService roomService,
            IBookingService bookingService)
        {
            _roomService = roomService;
            _bookingService = bookingService;
        }

        [HttpGet("GetAllRooms")]
        public async Task<ActionResult<List<Room>>> GetAllRooms()
        {
            List<Room> rooms = _roomService.GetAllRooms();

            return Ok(rooms);
        }

        [HttpPut("UpdateRoom")]
        public async Task<ActionResult<Room>> UpdateRoom(RoomUpdateDto updatedRoom)
        {
            var existingRoom = _roomService.GetRoomById(updatedRoom.RoomId);

            if (existingRoom == null)
            {
                return NotFound();
            }

            try
            {
                var result = _roomService.UpdateRoom(updatedRoom);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update the service.");
            }
        }

        [HttpDelete("DeleteRoom")]
        public async Task<ActionResult> DeleteRoom(int id)
        {
            var result = _roomService.DeleteRoom(id);

            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("CreateRoom")]
        public async Task<ActionResult<Room>> CreateRoom(RoomCreateDto room)
        {
            _roomService.CreateRoom(room);
            return Ok();
        }
    }
}
