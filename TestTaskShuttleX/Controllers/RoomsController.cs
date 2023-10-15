using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TestTaskShuttleX.Core.Interface;
using TestTaskShuttleX.Hubs;
using TestTaskShuttleX.Infrastructure.Model;
using TestTaskShuttleX.Request;
using TestTaskShuttleX.Response;

namespace TestTaskShuttleX.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly ILiveConnectionService _liveConntectionService;
        private readonly IHubContext<ChatHub> _hubContext;
        public RoomsController(IRoomService roomService, IHubContext<ChatHub> hubContext, ILiveConnectionService liveConntectionService)
        {
            _roomService = roomService;
            _hubContext = hubContext;
            _liveConntectionService = liveConntectionService;
        }

        //public async Task<IActionResult> JoinRoom([FromBody] JoinRoomRequest request)
        //{
        //    //await _roomService.JoinRoom();

        //    await _hubContext.Clients.All.SendAsync("joinChatRoom", request.UserId);

        //    return Ok();
        //}

        [HttpGet]
        public async Task<IActionResult> FindRoomByName([FromQuery] FindRoomRequest request)
        {
            //for convenience, return one room, although in theory there can be many of them by name, so as not to connect a mapper
            try
            {
                var findRoom = _roomService.GetRoomByName(request.RoomName);

                return Ok(findRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var findRoom = _roomService.GetRoomById(id);

                return Ok(findRoom);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roomService.GetAllRoomsAsync();

            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoomRequest request)
        {
            try
            {
                var newRoom = await _roomService.CreateRoom(request.UserId, request.RoomName);

                var response = new CreateRoomResponse()
                {
                    Id = newRoom.Id,
                    Name = newRoom.Name,
                    ChatAdminId = newRoom.ChatAdminId
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteRoomRequest request)
        {
            try
            {
                _roomService.DeleteRoom(request.roomId, request.userId);
                await DisconnectAllUser(request.roomId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task DisconnectAllUser(int roomId)
        {
            var connection = _liveConntectionService.GetAll(roomId);

            await _hubContext.Clients.Group(roomId.ToString()).SendAsync("onRoomDeleted", "Chat is deleted by owner, disconecting...");

            foreach (var item in connection)
            {
                await _hubContext.Groups.RemoveFromGroupAsync(item.ConnectionId, roomId.ToString());
            }
        }
    }
}
