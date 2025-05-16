using MentalHealth.DAL.Enums.Chat;

namespace MentalHealth.DAL.Entities.Chats.Chat;

public class ChatMessage
{
	public Guid Id { get; set; }
	public Guid SessionId { get; set; }
	public Sender Sender { get; set; }
	public string Content { get; set; }
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	public ChatSession Session { get; set; } = null!;
}
