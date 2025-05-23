using AutoMapper;
using MentalHealth.BLL.DTOs.Chats.ChatSession;
using MentalHealth.BLL.Interfaces.Chats;
using MentalHealth.DAL.Entities.Chats.Chat;
using MentalHealth.DAL.Interfaces.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealth.BLL.Services.Chats;

public class SessionService : ISessionService
{
	private readonly ISessionRepository _repository;
	private readonly IMapper _mapper;
	public SessionService(ISessionRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<Guid> CreateSession(CreateChatSessionDTO chatSessionDTO)
	{
		if (chatSessionDTO == null)
			throw new ArgumentNullException(nameof(chatSessionDTO));

		var sessionEntity = _mapper.Map<ChatSession>(chatSessionDTO);
		await _repository.CreateSessionAsync(sessionEntity);

		return sessionEntity.Id;
	}

	public async Task DeleteSession(Guid sessionId)
	{
		if (sessionId == Guid.Empty)
			throw new ArgumentException("Invalid session ID.");

		await _repository.DeleteSessionAsync(sessionId);
	}

	public async Task<ChatSessionDTO> GetSession(Guid sessionId)
	{
		if (sessionId == Guid.Empty)
			throw new ArgumentException("Invalid session ID.");

		var session = await _repository.GetSessionAsync(sessionId);
		if (session == null)
			throw new KeyNotFoundException($"Session with ID {sessionId} not found.");

		var sessionDto = _mapper.Map<ChatSessionDTO>(session);

		return sessionDto;
	}

	public async Task<IEnumerable<ChatSessionDTO>> GetSessionByUserId(Guid userId)
	{
		if (userId == Guid.Empty)
			throw new ArgumentException("Invalid user ID.");

		var sessions = await _repository.GetSessionsByUserAsync(userId);

		return _mapper.Map<IEnumerable<ChatSessionDTO>>(sessions);
	}

	public async Task<IEnumerable<ChatSessionDTO>> GetSessions()
	{
		var sessions = await _repository.GetChatSessionsAsync();

		if (sessions == null || !sessions.Any())
			throw new KeyNotFoundException($"No sessions found!");

		return _mapper.Map<IEnumerable<ChatSessionDTO>>(sessions);
	}

	public async Task UpdateSession(UpdateChatSessionDTO sessionDTO)
	{
		if (sessionDTO == null) 
			throw new ArgumentNullException(nameof(sessionDTO));

		var sessionEntity = _mapper.Map<ChatSession>(sessionDTO);
		await _repository.UpdateSessionAsync(sessionEntity);
	}
}
