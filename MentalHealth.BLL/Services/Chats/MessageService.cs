using AutoMapper;
using MentalHealth.BLL.DTOs.Chats.ChatMessage;
using MentalHealth.BLL.DTOs.Chats.ChatSession;
using MentalHealth.BLL.Interfaces.Chats;
using MentalHealth.DAL.Entities.Chats.Chat;
using MentalHealth.DAL.Interfaces.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MentalHealth.BLL.Services.Chats;

public class MessageService : IMessageService
{
	private readonly IMessageRepository _repository;
	private readonly IMapper _mapper;
	public MessageService(IMessageRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}
	public async Task<Guid> CreateMessage(CreateChatMessageDTO messageDto)
	{
		if (messageDto == null)
			throw new ArgumentNullException(nameof(messageDto));

		var messageEntity = _mapper.Map<ChatMessage>(messageDto);
		await _repository.AddMessageAsync(messageEntity);

		return messageEntity.Id;
	}

	public async Task DeleteMessage(Guid messageId)
	{
		if (messageId == Guid.Empty)
			throw new ArgumentException("Invalid session ID.");

		await _repository.DeleteMessageAsync(messageId);
	}

	public async Task<ChatMessageDTO> GetMessage(Guid messageId)
	{
		if (messageId == Guid.Empty)
			throw new ArgumentException("Invalid session ID.");

		var message = await _repository.GetMessageByIdAsync(messageId);
		if (message == null)
			throw new KeyNotFoundException($"Message with ID {message} not found.");

		return _mapper.Map<ChatMessageDTO>(message);
	}

	public async Task<IEnumerable<ChatMessageDTO>> GetMessageBySession(Guid sessionId)
	{
		if (sessionId == Guid.Empty)
			throw new ArgumentException("Invalid session ID.");

		var messages = await _repository.GetMessagesBySessionAsync(sessionId);
		if (messages == null || !messages.Any())
			throw new KeyNotFoundException($"No messages found!");

		var messagesDto = _mapper.Map<IEnumerable<ChatMessageDTO>>(messages);
		return messagesDto;
	}

	public async Task<IEnumerable<ChatMessageDTO>> GetMessages()
	{
		var messages = await _repository.GetMessagesAsync();
		if (messages == null || !messages.Any())
			throw new KeyNotFoundException($"No messages found!");

		return _mapper.Map<IEnumerable<ChatMessageDTO>>(messages);
	}

	public async Task UpdateMessage(ChatMessageDTO messageDto)
	{
		if (messageDto == null)
			throw new ArgumentNullException(nameof(messageDto));

		var messageEntity = _mapper.Map<ChatMessage>(messageDto);
		await _repository.UpdateMessageAsync(messageEntity);
	}
}
