using Matemagicas.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Matemagicas.Api.Infrastructure.Context;

public class MatemagicasDbContext(DbContextOptions<MatemagicasDbContext> options) : DbContext(options)
{
   public DbSet<Game> Games { get; set; } 
   public DbSet<Question> Questions { get; set; } 
   public DbSet<User> Users { get; set; }
}