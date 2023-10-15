using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Infrastructure.Interface
{
    public interface IRoomRepository : IRepository<Room>
    {
        public Room FindByName(string roomName);
    }
}
