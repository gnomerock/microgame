using Microsoft.EntityFrameworkCore;

namespace Microgame.Models;

public class EnemyContext : DbContext
{
  public EnemyContext(DbContextOptions<EnemyContext> options)
      : base(options)
  {
  }

  public DbSet<Enemy> Enemies { get; set; } = null!;
}