namespace MentalHealth.BLL.DTOs.Chats.ChatSession;

public class UpdateChatSessionDTO
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public DateTime? LastVisit { get; set; }
}
