using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskShuttleX.Controllers;
using TestTaskShuttleX.Infrastructure;
using TestTaskShuttleX.Infrastructure.Model;

namespace TestTaskShuttleX.Test
{
    public class RoomTest
    {
        //put in a separate class
        private ApplicationDbContext GetDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

            var context = new ApplicationDbContext(dbContextOptions);

            context.Database.EnsureCreated();

            context.Rooms.Add(new Room
            {
                Name = "test",
                Id = 2,
                ChatAdminId = 1,
            });
            context.SaveChanges();
            return context;
        }


        [Fact]
        public void GetRoomFromName()
        {
            var db = GetDbContext();

            var result = db.Rooms.FirstOrDefault(r => r.Name == "test");

            Assert.NotNull(result);
        }
    }
}
