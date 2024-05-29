namespace Project1.Models;

public class Player : LivingThing
{
    public Guid PlayerID { get; set; }
    public int PlayerLevel { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public Weapon EquippedWeapon { get; set; }
    public Armor EquippedArmor { get; set; }
    public int PlayerXP { get; set; }
    public int CurrentLocation { get; set; }
    public List<string> PlayerMap { get; set; }
    public List<int> ExploredLocations { get; set; }
    public int PlayerGold { get; set; }
    public List<Item> InventoryItems { get; set; }
    public List<Weapon> InventoryWeapons { get; set; }
    public List<Armor> InventoryArmors { get; set; }
    public List<Potion> InventoryPotions { get; set; }

}