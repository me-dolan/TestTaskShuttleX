using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskShuttleX.Infrastructure.Interface;
using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Infrastructure.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Message>();
        }

        public override Message FindById(int id)
        {
            var entity = _dbSet.Include(m => m.Room).FirstOrDefault(m => m.Id == id);

            return entity;
        }
    }
}
