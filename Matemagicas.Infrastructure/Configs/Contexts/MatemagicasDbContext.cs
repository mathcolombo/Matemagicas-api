using Matemagicas.Domain.Schools.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Matemagicas.Infrastructure.Configs.Contexts;

public class MatemagicasDbContext(DbContextOptions<MatemagicasDbContext> options) : DbContext(options)
{
   // public DbSet<Game> Games { get; set; } 
   // public DbSet<Question> Questions { get; set; } 
   // public DbSet<User> Users { get; set; }
   public DbSet<School> Schools { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<School>().ToCollection("schools");
      // modelBuilder.Entity<Question>().ToCollection("questions");
      // modelBuilder.Entity<User>().ToCollection("users");
   }
}