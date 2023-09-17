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
  public int MaxHealthPoint { get; set;}
  public int CurrentHealthPoint { get; set;}
  public int AttackPoint { get; set;}
  public int DefensePoint { get; set;}

  private Equipment? Weapon { get; set;}
  private Equipment? Armor { get; set;}

  public string getCurrentHP() {
    return Name+" HP: "+CurrentHealthPoint.ToString()+"/"+MaxHealthPoint.ToString()+" AP: "+getAP()+" DP: "+getDP();
  }

  public int getAP() {
    if(Weapon != null) {
      return Weapon.AttackPoint+AttackPoint;
    }else{
      return AttackPoint;
    }
  }

  public int getDP() {
    if(Armor != null) {
      return Armor.DefensePoint+DefensePoint;
    }else{
      return DefensePoint;
    }
  }

  public void equipWeapon(Equipment weapon) {
    Weapon = weapon;
  }

  public void equipArmor(Equipment armor) {
    Armor = armor;
  }

  public Equipment? getEquipedWeapon() {
    return Weapon;
  }

  public bool isDead() {
    return CurrentHealthPoint == 0;
  }
}