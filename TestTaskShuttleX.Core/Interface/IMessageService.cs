using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskShuttleX.Core.DTO;

namespace TestTaskShuttleX.Core.Interface
{
    public interface IMessageService
    {
        void AddMessage(MessageDTO messageDTO);
    }
}
