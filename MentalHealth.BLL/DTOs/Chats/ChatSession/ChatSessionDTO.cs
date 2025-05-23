
using MentalHealth.BLL.DTOs.Chats.ChatMessage;

namespace MentalHealth.BLL.DTOs.Chats.ChatSession;

public class ChatSessionDTO
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public DateTime StartedAt { get; set; }
	public DateTime? LastVisit { get; set; }

	public List<ChatMessageDTO> Messages { get; set; } = new();
}
