using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskShuttleX.Core.DTO;
using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Core.Interface
{
    public interface ILiveConnectionService
    {
        void Create(string connectionId);
        void Delete(string connectionId);
        void Update(LiveConnection connection);
        LiveConnection Get(string connectionId);
        IEnumerable<LiveConnection> GetAll(int roomId);
    }
}
