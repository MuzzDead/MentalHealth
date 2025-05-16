using MentalHealth.DAL.Entities.Chats.Chat;
using MentalHealth.DAL.Enums.User;

namespace MentalHealth.DAL.Entities.User;

public class UserEntity
{
	public Guid Id { get; set; }
	public string Username { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public string? GlobalPromt { get; set; }
	public UserRole UserRole { get; set; } = UserRole.User;
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	public List<ChatSession> Sessions { get; set; } = new();
}
