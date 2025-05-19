using MentalHealth.DAL.Entities.Chats.Chat;
using MentalHealth.DAL.Interfaces.Chats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MentalHealth.DAL.Repositories.Chats
{
	public class SessionRepository : ISessionRepository
	{
		public readonly ApplicationDbContext _context;
		public SessionRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task CreateSessionAsync(ChatSession chatSession)
		{
			if (chatSession == null) throw new ArgumentNullException(nameof(chatSession));
			await _context.Sessions.AddAsync(chatSession);
		}

		public async Task DeleteSessionAsync(Guid chatId)
		{
			var existingSession = await GetSessionAsync(chatId);
			if (existingSession == null)
				throw new KeyNotFoundException($"ChatSession with ID {chatId} not found.");


			_context.Sessions.Remove(existingSession);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<ChatSession>> GetChatSessionsAsync()
		{
			return await _context.Sessions
				.Include(s => s.User)
				.ToListAsync();
		}

		public async Task<ChatSession?> GetSessionAsync(Guid chatId)
		{
			return await _context.Sessions
				.Include(s => s.User)
				.Include(s => s.Messages)
				.FirstOrDefaultAsync(s => s.Id == chatId);
		}

		public async Task<IEnumerable<ChatSession>> GetSessionsByUserAsync(Guid userId)
		{
			return await _context.Sessions
				.Where(s => s.UserId == userId)
				.OrderByDescending(s => s.LastVisit ?? s.StartedAt)
				.ToListAsync();
		}

		public async Task UpdateSessionAsync(ChatSession chatSession)
		{
			var existing = await GetSessionAsync(chatSession.Id);
			if (existing == null)
				throw new KeyNotFoundException($"ChatSession with ID {chatSession.Id} not found.");

			_context.Sessions.Update(chatSession);
			await _context.SaveChangesAsync();
		}
	}
}