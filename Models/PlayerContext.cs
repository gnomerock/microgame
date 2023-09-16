using Microsoft.EntityFrameworkCore;

namespace Microgame.Models;

public class PlayerContext : DbContext
{
    public PlayerContext(DbContextOptions<PlayerContext> options)
        : base(options)
    {
    }

    public DbSet<PlayerContext> Players { get; set; } = null!;
}