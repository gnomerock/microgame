namespace Microgame.Models;

public class Enemy 
{
  public long Id { get; set;}
  public string? Name { get; set;}

  public int MaxHealthPoint { get; set;}
  public int CurrentHealthPoint { get; set;}
  public int AttackPoint { get; set;}
  public int DefensePoint { get; set;}
}