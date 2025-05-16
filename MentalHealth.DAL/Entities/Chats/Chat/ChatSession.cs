using MentalHealth.DAL.Entities.User;

namespace MentalHealth.DAL.Entities.Chats.Chat;

public class ChatSession
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public Guid UserId { get; set; }
	public DateTime StartedAt { get; set; } = DateTime.UtcNow;
	public DateTime? LastVisit { get; set; }

	public List<ChatMessage> Messages { get; set; } = new();
	public UserEntity User { get; set; } = null!;
}