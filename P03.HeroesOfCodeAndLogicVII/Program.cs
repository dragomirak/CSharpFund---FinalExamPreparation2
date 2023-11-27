using static System.Net.Mime.MediaTypeNames;

namespace P03.HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int heroesCount = int.Parse(Console.ReadLine());
            List<Hero> heroes = new List<Hero>();

            for (int i = 0; i < heroesCount; i++)
            {
                string[] heroData = Console.ReadLine().Split(" ").ToArray();
                string heroName = heroData[0];
                int hitPoints = int.Parse(heroData[1]);
                int manaPoints = int.Parse(heroData[2]);

                Hero hero = new Hero(heroName, hitPoints, manaPoints);
                heroes.Add(hero);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] instructions = input.Split(" - ");
                string action = instructions[0];
                string heroName = instructions[1];
                Hero foundHero = heroes.First(h => h.HeroName == heroName);

                if (action == "CastSpell")
                {
                    int mpNeeded = int.Parse(instructions[2]);
                    string spellName = instructions[3];
                    foundHero.CastSpell(heroName, mpNeeded, spellName);
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(instructions[2]);
                    string attacker = instructions[3];
                    foundHero.TakeDamage(heroName, damage, attacker);
                }
                else if (action == "Recharge")
                {
                    int mpAmount = int.Parse(instructions[2]);
                    foundHero.Recharge(heroName, mpAmount);
                }
                else if (action == "Heal")
                {
                    int hpAmount = int.Parse(instructions[2]);
                    foundHero.Heal(heroName, hpAmount);
                }
            }

            heroes.RemoveAll(h => h.HitPoints <= 0);
            foreach (Hero hero in heroes)
            {
                Console.WriteLine(hero.ToString());
            }
        }
    }
}