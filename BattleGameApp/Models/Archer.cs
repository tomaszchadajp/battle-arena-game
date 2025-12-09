namespace BattleGameApp.Models
{
    public class Archer : Character
    {
        public Archer() : base("£ucznik", 100, 12, "Szybki i celny. Zbalansowane statystyki", "archer.png") { }

        public override int Attack(Character target)
        {
            int dmg = Strength;

            bool isCriticalAttack = new Random().Next(100) < 25;
            if (isCriticalAttack)
            {
                dmg *= 2;
            }

            target.ReceiveDamage(dmg);

            return dmg;
        }
    }
}
