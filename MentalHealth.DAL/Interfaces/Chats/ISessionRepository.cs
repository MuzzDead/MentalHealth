using MentalHealth.DAL.Entities.Chats.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealth.DAL.Interfaces.Chats;

public interface ISessionRepository
{
	Task<IEnumerable<ChatSession>> GetChatSessionAsync();
	Task<ChatSession> GetSessionAsync(Guid chatId);
	Task CreateSessionAsync (ChatSession chatSession);
	Task DeleteSessionAsync (Guid chatId);
	Task UpdateSessionAsync (ChatSession chatSession);
	Task<IEnumerable<ChatSession>> GetSessionsByUserAsync(Guid userId);
}
