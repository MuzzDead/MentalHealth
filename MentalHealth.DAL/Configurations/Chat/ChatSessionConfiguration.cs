using MentalHealth.DAL.Entities.Chats.Chat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentalHealth.DAL.Configurations.Chat;

public class ChatSessionConfiguration : IEntityTypeConfiguration<ChatSession>
{
	public void Configure(EntityTypeBuilder<ChatSession> builder)
	{
		builder.HasKey(cs => cs.Id);

		builder.Property(cs => cs.Title)
			.IsRequired();

		builder.HasOne(cs => cs.User)
			.WithMany(u => u.Sessions)
			.HasForeignKey(cs => cs.UserId);

		builder.HasMany(cs => cs.Messages)
			.WithOne(m => m.Session)
			.HasForeignKey(m => m.SessionId);
	}
}
