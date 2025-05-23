
using MentalHealth.DAL.Enums.Chat;

namespace MentalHealth.BLL.DTOs.Chats.ChatMessage;

public class CreateChatMessageDTO
{
	public Guid SessionId { get; set; }
	public Sender Sender { get; set; }
	public string Content { get; set; } = string.Empty;
}
