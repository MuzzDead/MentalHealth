using MentalHealth.DAL.Enums.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealth.BLL.DTOs.Chats.ChatMessage;

public class UpdateChatMessageDTO
{
	public Guid Id { get; set; }
	public Guid SessionId { get; set; }
	public Sender Sender { get; set; }
	public string Content { get; set; } = string.Empty;
}
