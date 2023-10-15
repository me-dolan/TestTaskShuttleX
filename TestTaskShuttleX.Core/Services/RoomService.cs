using Microsoft.AspNetCore.SignalR;
using TestTaskShuttleX.Core.DTO;
using TestTaskShuttleX.Core.Interface;
using TestTaskShuttleX.Infrastructure;
using TestTaskShuttleX.Infrastructure.Interface;
using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<RoomDTO> CreateRoom(int userId, string roomName)
        {
            var room = new Room()
            {
                ChatAdminId = userId,
                Name = roomName,
            };

            await _roomRepository.CreateAsync(room);

            var roomDTO = new RoomDTO()
            {
                Id = room.Id,
                ChatAdminId = room.ChatAdminId,
                Name = room.Name,
            };

            return roomDTO;
        }

        public void DeleteRoom(int roomId, int userId)
        {
            var room = _roomRepository.FindById(roomId);

            if (room == null)
            {
                throw new Exception("room is not found");
            }

            if (room.ChatAdminId != userId)
            {
                throw new Exception("You are not chat admin. You can't delete this chat room");
            }
            else
            {
                _roomRepository.Delete(room);
            }
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            var rooms = _roomRepository.GetAllAsync();

            return await rooms;
        }

        public RoomDTO GetRoomById(int roomId)
        {
            var findRoom = _roomRepository.FindById(roomId);

            if (findRoom == null)
            {
                throw new Exception("Not found");
            }

            var roomDTO = new RoomDTO()
            {
                Id = findRoom.Id,
                ChatAdminId = findRoom.ChatAdminId,
                Name = findRoom.Name,
                //Messages = findRoom.Messages,
                //ChatUserId = findRoom.ChatUserId
            };

            return roomDTO;
        }

        public RoomDTO GetRoomByName(string nameRoom)
        {
            var findRoom = _roomRepository.FindByName(nameRoom);

            if (findRoom == null)
            {
                throw new Exception("Not found");
            }

            var roomDTO = new RoomDTO()
            {
                Id = findRoom.Id,
                ChatAdminId = findRoom.ChatAdminId,
                Name = findRoom.Name,
                //Messages = findRoom.Messages,
                //ChatUserId = findRoom.ChatUserId
            };

            return roomDTO;
        }
    }
}
