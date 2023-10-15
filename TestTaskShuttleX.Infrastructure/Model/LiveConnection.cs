using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskShuttleX.Infrastructure.Model
{
    public class LiveConnection
    {
        [Key]
        public int Id { get; set; }
        public string ConnectionId { get; set; }
        public int CurrentChatId { get; set; }
        public int UserId { get; set; }
    }
}
