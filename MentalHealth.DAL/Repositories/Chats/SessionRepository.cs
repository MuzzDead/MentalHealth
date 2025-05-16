using MentalHealth.DAL.Entities.Chats.Chat;
using MentalHealth.DAL.Interfaces.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealth.DAL.Repositories.Chats
{
	public class SessionRepository : ISessionRepository
	{
		public readonly ApplicationDbContext _context;
		public SessionRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public Task CreateSessionAsync(ChatSession chatSession)
		{
			throw new NotImplementedException();
		}

		public Task DeleteSessionAsync(Guid chatId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ChatSession>> GetChatSessionAsync()
		{
			throw new NotImplementedException();
		}

		public Task<ChatSession> GetSessionAsync(Guid chatId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ChatSession>> GetSessionsByUserAsync(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task UpdateSessionAsync(ChatSession chatSession)
		{
			throw new NotImplementedException();
		}
	}
}
