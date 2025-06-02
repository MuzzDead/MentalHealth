using MentalHealth.BLL.DTOs.Chats.ChatMessage;
using MentalHealth.BLL.Interfaces.Chats;
using Microsoft.AspNetCore.SignalR;

namespace MentalHealth.WebAPI.Hubs;

public class ChatHub : Hub
{
	private readonly IMessageService _service;
	public ChatHub(IMessageService service)
	{
		_service = service;
	}

	public async Task JoinSession(Guid sessionId)
	{
		await Groups.AddToGroupAsync(Context.ConnectionId, sessionId.ToString());
	}

	public async Task LeaveSession(Guid sessionId)
	{
		await Groups.RemoveFromGroupAsync(Context.ConnectionId, sessionId.ToString());
	}

	public async Task SendMessage(Guid sessionId,CreateChatMessageDTO message)
	{
		await _service.CreateMessage(message);

		await Clients.Group(sessionId.ToString()).SendAsync("ReceiveMessage", message);
	}
}
