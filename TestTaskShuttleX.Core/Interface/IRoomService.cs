using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskShuttleX.Core.DTO;
using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Core.Interface
{
    public interface IRoomService
    {
        Task<RoomDTO> CreateRoom(int userId, string roomName);
        void DeleteRoom(int roomId, int userId);
        RoomDTO GetRoomByName(string nameRoom);
        RoomDTO GetRoomById(int roomId);
        Task<IEnumerable<Room>> GetAllRoomsAsync();
    }
}
