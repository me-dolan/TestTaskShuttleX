using TestTaskShuttleX.Infrastructure.Interface;
using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Infrastructure.Repository
{
    public class LiveConnectionRepository : Repository<LiveConnection>, ILiveConnectionRepository
    {
        private readonly ApplicationDbContext _context;
        public LiveConnectionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<LiveConnection>();
        }

        public LiveConnection Get(string connectionId)
        {
            var entrie = _dbSet.FirstOrDefault(l => l.ConnectionId == connectionId);

            return entrie;
        }
    }
}
