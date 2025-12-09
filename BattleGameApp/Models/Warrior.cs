namespace BattleGameApp.Models
{
    public class Warrior : Character
    {
        public Warrior() : base("Wojownik", 120, 15, "Wojownik walczący mieczem. Dużo HP, stabilne obrażenia.", "warrior.png") {}

        public override int Attack(Character target)
        {
            int dmg = Strength;
            target.ReceiveDamage(dmg);

            return dmg;
        }
    }
}
