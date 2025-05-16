using MentalHealth.DAL.Entities.Chats.Chat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentalHealth.DAL.Configurations.Chat;

public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
{
	public void Configure(EntityTypeBuilder<ChatMessage> builder)
	{
		builder.HasKey(m => m.Id);

		builder.Property(m => m.Content)
			.IsRequired();

		builder.HasOne(m => m.Session)
			.WithMany(cs => cs.Messages)
			.HasForeignKey(m => m.SessionId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(m => m.Sender)
			.HasConversion<int>()
			.IsRequired();
	}
}
