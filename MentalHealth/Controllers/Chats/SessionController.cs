using MentalHealth.BLL.DTOs.Chats.ChatSession;
using MentalHealth.BLL.Interfaces.Chats;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MentalHealth.WebAPI.Controllers.Chats;

[Route("api/[controller]")]
[ApiController]
public class SessionController : ControllerBase
{
	private readonly ISessionService _service;

	public SessionController(ISessionService session)
	{
		_service = session;
	}

	[HttpGet("{sessionId:guid}")]
	public async Task<ActionResult<ChatSessionDTO>> GetSession(Guid sessionId)
	{
		var session = await _service.GetSession(sessionId);
		if (session == null)
			return NotFound();

		return Ok(session);
	}

	[HttpDelete("{sessionId:guid}")]
	public async Task<ActionResult> DeleteSession(Guid sessionId)
	{
		var session = await GetSession(sessionId);
		if (session == null)
			return NotFound();

		await _service.DeleteSession(sessionId);
		return NoContent();
	}

	[HttpPost]
	public async Task<ActionResult> CreateSession([FromBody] CreateChatSessionDTO session)
	{
		await _service.CreateSession(session);
		return Ok(new { Message = "Session created successfully" });
	}

	[HttpGet("{userId:guid}")]
	public async Task<ActionResult<IEnumerable<ChatSessionDTO>>> GetUserSessions(Guid userId)
	{
		var sessions = await _service.GetSessionByUserId(userId);
		if(sessions == null)
			return NotFound();

		return Ok(sessions);
	}

	[HttpPut]
	public async Task<ActionResult> UpdateSession([FromBody] UpdateChatSessionDTO sessionDto)
	{
		var session = await GetSession(sessionDto.Id);
		if(session == null)
			return NotFound();

		await _service.UpdateSession(sessionDto);
		return Ok("Session updated successful!");
	}
}
