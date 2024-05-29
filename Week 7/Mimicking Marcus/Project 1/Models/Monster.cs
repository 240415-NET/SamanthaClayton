using Project1.Models;

namespace Projcet1.Models;
public class Monster : LivingThing

{
    public int MonsterID {get; set;}
    public int MonsterAttack {get; set;}
    public int MonsterDodge {get; set;}
    public int RewardXP {get; set;}
    public int RewardGold {get; set;}
    public string AttackText {get; set;}
    public string DodgeText {get; set;}
    public string HitText {get; set;}
    public int ChanceToFlee {get; set;}
    public List<string> MonsterDisplay {get; set;}
    public List<string> LootTable {get; set;}


    public Monster(string Name, int MaxHitPoints, int CurrentHitPoints, int MonsterID, int MonsterAttack, int MonsterDodge, int RewardXP, int RewardGold, string AttackText, string DodgeText, string HitText, int ChanceToFlee, List<string> MonsterDisplay) : base(Name, MaxHitPoints, CurrentHitPoints)
    {
        this.MonsterID = MonsterID;
        this.MonsterAttack = MonsterAttack;
        this.MonsterDodge = MonsterDodge;
        this.RewardXP = RewardXP;
        this.RewardGold = RewardGold;
        this.AttackText = AttackText;
        this.DodgeText = DodgeText;
        this.HitText = HitText;
        this.ChanceToFlee = ChanceToFlee;
        this.MonsterDisplay = MonsterDisplay;
    }
    public Monster(MonsterData baseMonster) : base(baseMonster.Name, baseMonster.MaxHitPoints, baseMonster.CurrentHitPoints)
    {
        MonsterID = baseMonster.MonsterID;
        MonsterAttack = baseMonster.MonsterAttack;
        MonsterDodge = baseMonster.MonsterDodge;
        RewardXP = baseMonster.RewardXP;
        RewardGold = baseMonster.RewardGold;
        AttackText = baseMonster.AttackText;
        DodgeText = baseMonster.DodgeText;
        HitText = baseMonster.HitText;
        ChanceToFlee = baseMonster.ChanceToFlee;
        MonsterDisplay = baseMonster.MonsterDisplay;
        LootTable = baseMonster.LootTable;
    }


}

public struct MonsterData
{
    public string Name {get; set;}
    public int MaxHitPoints {get; set;}
    public int CurrentHitPoints {get; set;}
    public int MonsterID {get; set;}
    public int MonsterAttack {get; set;}
    public int MonsterDodge {get; set;}
    public int RewardXP {get; set;}
    public int RewardGold {get; set;}
    public string AttackText {get; set;}
    public string DodgeText {get; set;}
    public string HitText {get; set;}
    public int ChanceToFlee {get; set;}
    public List<string> MonsterDisplay {get; set;}
    public List<string> LootTable {get; set;}

    public MonsterData(string Name, int MaxHitPoints, int CurrentHitPoints, int MonsterID, int MonsterAttack, int MonsterDodge, int RewardXP, int RewardGold, string AttackText, string DodgeText, string HitText, int ChanceToFlee, List<string> MonsterDisplay, List<string> LootTable)
    {
        this.Name = Name;
        this.MaxHitPoints = MaxHitPoints;
        this.CurrentHitPoints = CurrentHitPoints;
        this.MonsterID = MonsterID;
        this.MonsterAttack = MonsterAttack;
        this.MonsterDodge = MonsterDodge;
        this.RewardXP = RewardXP;
        this.RewardGold = RewardGold;
        this.AttackText = AttackText;
        this.DodgeText = DodgeText;
        this.HitText = HitText;
        this.ChanceToFlee = ChanceToFlee;
        this.MonsterDisplay = MonsterDisplay;
        this.LootTable = LootTable;
    }
}