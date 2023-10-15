using Microsoft.AspNetCore.SignalR;
using TestTaskShuttleX.Core.DTO;
using TestTaskShuttleX.Core.Interface;

namespace TestTaskShuttleX.Hubs
{
    public class ChatHub : Hub
    {
        public readonly static Dictionary<string, string> _connectionsUser = new();
        private readonly IMessageService _messageService;
        private readonly IRoomService _roomService;
        ILiveConnectionService _liveConntectionService;
        public ChatHub(IRoomService roomService, IMessageService messageService, ILiveConnectionService liveConntectionService)
        {
            _roomService = roomService;
            _messageService = messageService;
            _liveConntectionService = liveConntectionService;
        }

        public async Task SendMessage(int chatRoomId, string userId, string message)
        {
            var chatRoom = _roomService.GetRoomById(chatRoomId);
            if (chatRoom == null)
            {
                await Clients.Caller.SendAsync("errorJoinChat", "Chat with this id doesn't exist");
                return;
            }

            await Clients.Group(chatRoomId.ToString()).SendAsync("ReceiveMessage", userId, message);
            _messageService.AddMessage(new MessageDTO
            {
                ContentMessage = message,
                RoomId = chatRoomId,
                SenderId = Convert.ToInt32(userId),
                Timestamp = DateTime.Now
            });
        }

        public async Task JoinRoom(int chatId, int userId)
        {
            var chat = _roomService.GetRoomById(chatId);
            if (chat == null)
            {
                await Clients.Caller.SendAsync("errorJoinChat", "Chat with this id doesn't exist");
                return;
            }

            var connection = _liveConntectionService.Get(Context.ConnectionId);
            if (connection != null)
            {
                if (connection.ConnectionId != Context.ConnectionId && connection.UserId == userId)
                {
                    await Clients.Caller.SendAsync("errorChat", "This user is already connected");
                    return;
                }

                if (connection.CurrentChatId != 0)
                    await Groups.RemoveFromGroupAsync(connection.ConnectionId!, connection.CurrentChatId.ToString()!);

                await Groups.AddToGroupAsync(connection.ConnectionId!, chatId.ToString());
                connection.CurrentChatId = chatId;
                connection.UserId = userId;

                _liveConntectionService.Update(connection);

                await Clients.OthersInGroup(chatId.ToString()).SendAsync("addUserChat", userId);
            }
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            _liveConntectionService.Create(Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _liveConntectionService.Delete(Context.ConnectionId);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
