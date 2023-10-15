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
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Room>();
        }

        public Room FindByName(string roomName)
        {
            var entrie = _dbSet
                //.Include(r => r.ChatUserId)
                //.Include(r => r.Messages)
                .FirstOrDefault(r => r.Name == roomName);

            return entrie;
        }

        public override Room FindById(int id)
        {
            var entrie = _dbSet
                //.Include(r => r.ChatUserId)
                //.Include(r => r.Messages)
                .FirstOrDefault(r => r.Id == id);

            return entrie;
        }
    }
}
