using MentalHealth.DAL.Enums.Chat;
using System.Reflection;

namespace MentalHealth.BLL.DTOs.Chats.ChatMessage;

public class ChatMessageDTO
{
	public Guid Id { get; set; }
	public string Content { get; set; } = string.Empty;
	public DateTime CreatedAt { get; set; }
	public Sender Sender { get; set; }
}
