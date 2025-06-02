using MentalHealth.BLL.DTOs.Chats.ChatMessage;
using MentalHealth.BLL.Interfaces.Chats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentalHealth.WebAPI.Controllers.Chats;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
	private readonly IMessageService _service;
	public MessageController(IMessageService service)
	{
		_service = service;
	}

	[HttpGet("{messageId:guid}")]
	public async Task<ActionResult<ChatMessageDTO>> GetMessage(Guid messageId)
	{
		var message = await _service.GetMessage(messageId);
		if (message == null)
			return NotFound();

		return Ok(message);
	}

	[HttpGet("{sessionId:guid}")]
	public async Task<ActionResult<IEnumerable<ChatMessageDTO>>> GetMessagesBySession(Guid sessionId)
	{
		var messages = await _service.GetMessageBySession(sessionId);
		if(messages == null)
			return NotFound();

		return Ok(messages);
	}

	[HttpPost]
	public async Task<ActionResult> CreateMessage([FromBody] CreateChatMessageDTO messageDto)
	{
		await _service.CreateMessage(messageDto);
		return Ok(new { Message = "Session created successfully" });
	}

	[HttpPut]
	public async Task<ActionResult> UpdateMessage([FromBody] ChatMessageDTO messageDto)
	{
		var message = await GetMessage(messageDto.Id);
		if (message == null)
			return NotFound();

		await _service.UpdateMessage(messageDto);
		return Ok("Message updated successful!");
	}

	[HttpDelete("{messageId:guid}")]
	public async Task<ActionResult> DeleteMessage(Guid messageId)
	{
		var message = await GetMessage(messageId);
		if(message == null)
			return NotFound();

		await _service.DeleteMessage(messageId);
		return NoContent();
	}
}
