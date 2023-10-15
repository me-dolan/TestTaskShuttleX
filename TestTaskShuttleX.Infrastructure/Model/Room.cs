using System.ComponentModel.DataAnnotations;

namespace TestTaskShuttleX.Infrastructure.Model
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// id user created chat
        /// </summary>
        public int ChatAdminId { get; set; }

        public IEnumerable<Message> Messages { get; set; }
    }
}
