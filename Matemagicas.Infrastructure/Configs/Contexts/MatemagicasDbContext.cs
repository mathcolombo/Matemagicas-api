using Microsoft.EntityFrameworkCore;

namespace Matemagicas.Infrastructure.Configs.Contexts;

public class MatemagicasDbContext(DbContextOptions<MatemagicasDbContext> options) : DbContext(options)
{
   // public DbSet<Game> Games { get; set; } 
   // public DbSet<Question> Questions { get; set; } 
   // public DbSet<User> Users { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
      // modelBuilder.Entity<Game>().ToCollection("games");
      // modelBuilder.Entity<Question>().ToCollection("questions");
      // modelBuilder.Entity<User>().ToCollection("users");
   }
}