using MentalHealth.DAL.Entities.Chats.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealth.DAL.Interfaces.Chats;

public interface IMessageRepository
{
	Task DeleteMessageAsync(Guid messageId);
	Task UpdateMessageAsync(ChatMessage chatMessage);
	Task AddMessageAsync(ChatMessage chatMessage);
	Task<ChatMessage> GetMessageByIdAsync(Guid messageId);
	Task<IEnumerable<ChatMessage>> GetMessagesAsync();
	Task<IEnumerable<ChatMessage>> GetMessagesBySessionAsync(Guid sessionId);
}
