namespace Microgame.Models;
using System.ComponentModel.DataAnnotations.Schema;

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

  public Equipment? Weapon { get; set;}
  public Equipment? Armor { get; set;}

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

  public void getAttacked(int damage) {
    CurrentHealthPoint -= damage;
    if(CurrentHealthPoint<0) CurrentHealthPoint=0;
    Console.WriteLine("HP:" + CurrentHealthPoint.ToString());
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