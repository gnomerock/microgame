using Microsoft.EntityFrameworkCore;

namespace Microgame.Models;

public class EquipmentContext : DbContext
{
  public EquipmentContext(DbContextOptions<EquipmentContext> options)
      : base(options)
  {
  }

  public DbSet<Equipment> Equipments { get; set; } = null!;
}