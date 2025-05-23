using MentalHealth.BLL.DTOs.Chats.ChatMessage;

namespace MentalHealth.BLL.Interfaces.Chats;

public interface IMessageService
{
	Task<IEnumerable<ChatMessageDTO>> GetMessageBySession(Guid sessionId);
	Task<Guid> CreateMessage(CreateChatMessageDTO messageDto);
	Task<ChatMessageDTO> GetMessage(Guid messageId);
	Task DeleteMessage(Guid messageId);
	Task UpdateMessage(ChatMessageDTO messageDto);
	Task<IEnumerable<ChatMessageDTO>> GetMessages();
}
