using MentalHealth.DAL.Entities.Chats.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealth.DAL.Interfaces.Chats;

public interface ISessionRepository
{
	Task<ChatSession?> GetSessionAsync(Guid chatId);
	Task<IEnumerable<ChatSession>> GetChatSessionsAsync();
	Task<IEnumerable<ChatSession>> GetSessionsByUserAsync(Guid userId);
	Task CreateSessionAsync (ChatSession chatSession);
	Task UpdateSessionAsync (ChatSession chatSession);
	Task DeleteSessionAsync (Guid chatId);
}
