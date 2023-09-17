namespace Microgame.Models;

public class Player 
{
  public long Id { get; set; }
  public string? Name { get; set;}
  public int MaxHealthPoint { get; set;}
  public int MaxStaminaPoint { get; set;}
  public int CurrentHealthPoint { get; set;}
  public int CurrentStaminaPoint { get; set;}
  public int Attack { get; set;}
  public int Defense { get; set;}
}