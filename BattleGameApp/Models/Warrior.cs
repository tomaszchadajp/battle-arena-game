namespace BattleGameApp.Models
{
    public class Warrior : Character
    {
        public Warrior() : base("Wojownik", 120, 15, "Wojownik walczący mieczem. Dużo HP, stabilne obrażenia.") {}

        public override string Attack(Character target)
        {
            int dmg = Strength;
            target.ReceiveDamage(dmg);

            return $"{Name} uderza za {dmg} dmg! {target.Name} ma {target.Health} HP.";
        }
    }
}
