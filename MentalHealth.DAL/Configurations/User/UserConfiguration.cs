using MentalHealth.DAL.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MentalHealth.DAL.Configurations.User;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
	public void Configure(EntityTypeBuilder<UserEntity> builder)
	{
		builder.HasKey(u => u.Id);

		builder.HasMany(u => u.Sessions)
			.WithOne(cs => cs.User)
			.HasForeignKey(cs => cs.UserId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(u => u.Username)
			.IsRequired()
			.HasMaxLength(20)
			.IsUnicode();

		builder.Property(u => u.GlobalPromt)
			.HasMaxLength(800);
	}
}
