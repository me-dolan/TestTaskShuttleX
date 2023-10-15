using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Core.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// id user created chat
        /// </summary>
        public int ChatAdminId { get; set; }

        public IEnumerable<Message>? Messages { get; set; }
        /// <summary>
        /// id users in room
        /// </summary>
    }
}
