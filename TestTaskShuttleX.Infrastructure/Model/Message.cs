using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskShuttleX.Infrastructure.Model
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string ContentMessage { get; set; }
        public DateTime Timestamp { get; set; }

        public int SenderId { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
