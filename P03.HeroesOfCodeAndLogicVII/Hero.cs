public class Hero
{
    public Hero(string heroName, int hitPoints, int manaPoints)
    {
        HeroName = heroName;
        HitPoints = hitPoints;
        ManaPoints = manaPoints;
    }

    public string HeroName { get; set; }
    public int HitPoints { get; set; }
    public int ManaPoints { get; set; }

    public void CastSpell(string heroName, int mpNeeded, string spellName)
    {
        if( ManaPoints >= mpNeeded)
        {
            ManaPoints -= mpNeeded;
            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {ManaPoints} MP!\"");
        }
        else
        {
            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
        }
    }

    public void TakeDamage(string heroName, int damage, string attacker)
    {
        HitPoints -= damage;
        if (HitPoints <= 0)
        {
            Console.WriteLine($"{heroName} has been killed by {attacker}!");
        }
        else
        {
            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {HitPoints} HP left!");
        }
    }

    public void Recharge(string heroName, int mpAmount)
    {
        int initialManaPoints = ManaPoints;
        ManaPoints += mpAmount;
        if (ManaPoints > 200) 
        { 
            ManaPoints = 200;
            Console.WriteLine($"{heroName} recharged for {ManaPoints - initialManaPoints} MP!");
        }
        else
        {
            Console.WriteLine($"{heroName} recharged for {mpAmount} MP!");
        }

    }

    public void Heal(string heroName, int hpAmount)
    {
        int initialHitPoints = HitPoints;
        HitPoints += hpAmount;
        if (HitPoints > 100)
        {
            HitPoints = 100;
            Console.WriteLine($"{heroName} healed for {HitPoints - initialHitPoints} HP!");
        }
        else
        {
            Console.WriteLine($"{heroName} healed for {hpAmount} HP!");
        }

    }

    public override string ToString()
    {
        string result = $"{HeroName}\r\n  HP: {HitPoints}\r\n  MP: {ManaPoints}";
        return result;
    }
}
