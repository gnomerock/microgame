using Microsoft.EntityFrameworkCore;

namespace Microgame.Models;

public class GameContext : DbContext
{
  public GameContext(DbContextOptions<GameContext> options)
      : base(options)
  {
  }

  public DbSet<Player> Players { get; set; } = null!;
  public DbSet<Enemy> Enemies { get; set; } = null!;
  public DbSet<Equipment> Equipments { get; set; } = null!;
}