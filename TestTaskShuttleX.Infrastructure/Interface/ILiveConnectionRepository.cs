using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Infrastructure.Interface
{
    public interface ILiveConnectionRepository : IRepository<LiveConnection>
    {
        LiveConnection Get(string connectionId);
    }
}
