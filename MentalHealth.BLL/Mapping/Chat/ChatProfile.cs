using AutoMapper;
using MentalHealth.BLL.DTOs.Chats.ChatMessage;
using MentalHealth.BLL.DTOs.Chats.ChatSession;
using MentalHealth.DAL.Entities.Chats.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealth.BLL.Mapping.Chat;

public class ChatProfile : Profile
{
	public ChatProfile()
	{
		CreateMap<ChatMessage, CreateChatMessageDTO>().ReverseMap();
		CreateMap<ChatMessage, ChatMessageDTO>().ReverseMap();

		CreateMap<ChatSession, ChatSessionDTO>().ReverseMap();
		CreateMap<ChatSession, CreateChatSessionDTO>().ReverseMap();
		CreateMap<ChatSession, UpdateChatSessionDTO>().ReverseMap();
	}
}
