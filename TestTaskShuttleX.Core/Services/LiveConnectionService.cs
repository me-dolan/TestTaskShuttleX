using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskShuttleX.Core.Interface;
using TestTaskShuttleX.Infrastructure.Interface;
using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Core.Services
{
    public class LiveConnectionService : ILiveConnectionService
    {
        private readonly ILiveConnectionRepository _liveConnectionRepository;
        public LiveConnectionService(ILiveConnectionRepository liveConnectionRepository)
        {
            _liveConnectionRepository = liveConnectionRepository;
        }

        public void Create(string connectionId)
        {
            _liveConnectionRepository.Create(new LiveConnection
            {
                ConnectionId = connectionId
            });
        }

        public void Delete(string connectionId)
        {
            var entrie = _liveConnectionRepository.Get(connectionId);
            if (entrie != null)
            {
                _liveConnectionRepository.Delete(entrie);
            }
        }

        public LiveConnection Get(string connectionId)
        {
            var entrie = _liveConnectionRepository.Get(connectionId);

            return entrie;
        }

        public IEnumerable<LiveConnection> GetAll(int roomId)
        {
            throw new NotImplementedException();
        }

        public void Update(LiveConnection connection)
        {
            _liveConnectionRepository.Update(connection);
        }
    }
}
