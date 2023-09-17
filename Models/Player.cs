namespace Microgame.Models;

public class Player 
{
  public Player() {
    MaxHealthPoint = 100;
    CurrentHealthPoint = 100;
    AttackPoint = 10;
    DefensePoint = 10;
  }
  public long Id { get; set; }
  public string? Name { get; set;}
  private int? MaxHealthPoint { get; set;}
  private int? CurrentHealthPoint { get; set;}
  private int? AttackPoint { get; set;}
  private int? DefensePoint { get; set;}

  private Equipment? Weapon { get; set;}

  public string getCurrentHP() {
    return Name+" HP: "+CurrentHealthPoint.ToString()+"/"+MaxHealthPoint.ToString();
  }

  public int? getAP() {
    return AttackPoint;
  }

  public int? getDP() {
    return DefensePoint;
  }

  public Equipment? getEquipedWeapon() {
    return Weapon;
  }
}