namespace BattleGameApp.Models
{
    public class Archer : Character
    {
        public Archer() : base("£ucznik", 100, 12, "Szybki i celny. Zbalansowane statystyki") { }

        public override string Attack(Character target)
        {
            int dmg = Strength;

            bool isCriticalAttack = new Random().Next(100) < 25;
            if (isCriticalAttack)
            {
                dmg *= 2;
            }

            target.ReceiveDamage(dmg);

            return $"{Name} strzela za {dmg} dmg! {(isCriticalAttack ? "(Atak krytyczny)" : "")} {target.Name} ma {target.Health} HP.";
        }
    }
}
