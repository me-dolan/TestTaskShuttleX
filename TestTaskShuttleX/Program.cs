using Microsoft.EntityFrameworkCore;
using TestTaskShuttleX.Core.Interface;
using TestTaskShuttleX.Core.Services;
using TestTaskShuttleX.Hubs;
using TestTaskShuttleX.Infrastructure;
using TestTaskShuttleX.Infrastructure.Interface;
using TestTaskShuttleX.Infrastructure.Repository;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSignalR();
        builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IRoomRepository, RoomRepository>();
        builder.Services.AddScoped<IMessageRepository, MessageRepository>();
        builder.Services.AddScoped<ILiveConnectionRepository, LiveConnectionRepository>();

        builder.Services.AddScoped<IMessageService, MessageService>();
        builder.Services.AddScoped<IRoomService, RoomService>();
        builder.Services.AddScoped<ILiveConnectionService, LiveConnectionService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.MapHub<ChatHub>("/chatHub");

        app.Run();
    }
}