using Matemagicas.Domain.Classes.Entities;
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
   public DbSet<Class> Classes { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<School>().ToCollection("schools");
      modelBuilder.Entity<Class>().ToCollection("classes");
   }
}