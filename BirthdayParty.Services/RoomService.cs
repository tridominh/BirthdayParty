using BirthdayParty.Models;
using BirthdayParty.Models.DTOs;
using BirthdayParty.Repository.Interfaces;
using BirthdayParty.Services.Interfaces;

namespace BirthdayParty.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<Room> GetAllRooms()
        {
            return _roomRepository.GetAll().ToList();
        }

        public Room GetRoomById(int id)
        {
            return _roomRepository.Get(id);
        }

        public Room UpdateRoom(RoomUpdateDto updatedRoom)
        {
            var room = new Room{
                RoomId = updatedRoom.RoomId,
                Capacity = updatedRoom.Capacity,
                RoomStatus = updatedRoom.RoomStatus,
            };
            return _roomRepository.Update(room);
        }

        public Room DeleteRoom(int id)
        {
            return _roomRepository.Delete(id);
        }

        public Room CreateRoom(RoomCreateDto room)
        {
            var roomObj = new Room{
                Capacity = room.Capacity,
                RoomStatus = "Pending",
            };
            return _roomRepository.Add(roomObj);
        }


    }
}
