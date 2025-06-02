
using MentalHealth.BLL.Interfaces.Chats;
using MentalHealth.BLL.Mapping.Chat;
using MentalHealth.BLL.Services.Chats;
using MentalHealth.DAL.Interfaces.Chats;
using MentalHealth.DAL.Repositories.Chats;
using MentalHealth.WebAPI.Hubs;

namespace MentalHealth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

			// Add Services & Repositories to the container
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            builder.Services.AddScoped<ISessionRepository, SessionRepository>();
            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<ISessionService, SessionService>();

			builder.Services.AddAutoMapper(typeof(ChatProfile).Assembly);
            builder.Services.AddSignalR();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


			app.MapHub<ChatHub>("/chat");

			app.MapControllers();

            app.Run();
        }
    }
}
