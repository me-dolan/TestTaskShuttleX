using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Core.DTO
{
    public class MessageDTO
    {
        public string ContentMessage { get; set; }
        public DateTime Timestamp { get; set; }

        public int SenderId { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
