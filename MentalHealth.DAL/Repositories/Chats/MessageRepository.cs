using MentalHealth.DAL.Entities.Chats.Chat;
using MentalHealth.DAL.Interfaces.Chats;
using Microsoft.EntityFrameworkCore;

namespace MentalHealth.DAL.Repositories.Chats;
public class MessageRepository : IMessageRepository
{
	private readonly ApplicationDbContext _context;
	public MessageRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task AddMessageAsync(ChatMessage chatMessage)
	{
		if (chatMessage == null) throw new ArgumentNullException(nameof(chatMessage));
		await _context.Messages.AddAsync(chatMessage);
	}

	public async Task DeleteMessageAsync(Guid messageId)
	{
		var existingMessage = await GetMessageByIdAsync(messageId);
		if (existingMessage == null)
			throw new KeyNotFoundException($"ChatMessage with ID {messageId} not found.");
		
		_context.Messages.Remove(existingMessage);
		await _context.SaveChangesAsync();
	}

	public async Task<ChatMessage> GetMessageByIdAsync(Guid messageId)
	{
		return await _context.Messages
			.Include(m => m.Session)
			.FirstOrDefaultAsync(m => m.Id == messageId);
	}

	public async Task<IEnumerable<ChatMessage>> GetMessagesAsync()
	{
		return await _context.Messages
			.ToListAsync();
	}

	public async Task<IEnumerable<ChatMessage>> GetMessagesBySessionAsync(Guid sessionId)
	{
		return await _context.Messages
			.Where(m => m.SessionId == sessionId)
			.ToListAsync();
	}

	public async Task UpdateMessageAsync(ChatMessage chatMessage)
	{
		var existingMessage = await GetMessageByIdAsync(chatMessage.Id);
		if (existingMessage == null)
			throw new KeyNotFoundException($"ChatMessage with ID {chatMessage.Id} not found.");

		_context.Messages.Update(chatMessage);
		await _context.SaveChangesAsync();
	}
}
