namespace Project1.Models;

public class Weapon : Item
{
    public int AttackIncrease { get; set; }
    public Weapon() : base()
    {

    }

    public Weapon(string ItemID, string ItemName, int ItemBaseValue, int QuantityOfItem, int AttackIncrease, int buyLvlRequirement) : base(ItemID, ItemName, ItemBaseValue, QuantityOfItem)
    {
        this.AttackIncrease = AttackIncrease;
        this.buyLvlRequirement = buyLvlRequirement;
    }

    // Haven't added in the ToString(), EquipOption(), VendorSellingDisplay(),
    //PlayerSeellingDislay(), or CopyFromOtherWeapon yet

}