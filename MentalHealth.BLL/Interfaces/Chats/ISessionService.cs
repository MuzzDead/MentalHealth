using MentalHealth.BLL.DTOs.Chats.ChatSession;

namespace MentalHealth.BLL.Interfaces.Chats;

public interface ISessionService
{
	Task DeleteSession(Guid sessionId);
	Task UpdateSession(UpdateChatSessionDTO sessionDTO);
	Task<Guid> CreateSession(CreateChatSessionDTO chatSessionDTO);
	Task<ChatSessionDTO> GetSession(Guid sessionId);
	Task<IEnumerable<ChatSessionDTO>> GetSessionByUserId(Guid userId);
	Task<IEnumerable<ChatSessionDTO>> GetSessions();
}
