using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskShuttleX.Core.DTO;
using TestTaskShuttleX.Core.Interface;
using TestTaskShuttleX.Infrastructure.Interface;
using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public void AddMessage(MessageDTO messageDTO)
        {
            _messageRepository.Create(new Message 
            { 
                RoomId = messageDTO.RoomId,
                SenderId = messageDTO.SenderId,
                Timestamp = messageDTO.Timestamp,
                ContentMessage = messageDTO.ContentMessage
            });
        }
    }
}
