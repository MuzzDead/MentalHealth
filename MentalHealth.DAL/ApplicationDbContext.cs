using MentalHealth.DAL.Configurations.Chat;
using MentalHealth.DAL.Configurations.User;
using MentalHealth.DAL.Entities.Chats.Chat;
using MentalHealth.DAL.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentalHealth.DAL;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions options) : base(options) { }

	public DbSet<UserEntity> Users { get; set; }
	public DbSet<ChatMessage> Messages { get; set; }
	public DbSet<ChatSession> Sessions { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new UserConfiguration());
		modelBuilder.ApplyConfiguration(new ChatSessionConfiguration());
		modelBuilder.ApplyConfiguration(new ChatMessageConfiguration());
	}
}
