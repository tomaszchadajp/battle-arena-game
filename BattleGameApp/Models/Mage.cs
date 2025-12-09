namespace BattleGameApp.Models
{
    public class Mage : Character
    {
        private int mana = 50;
        public Mage() : base("Mag", 90, 20, "Używa magii. Niskie HP, wysokie obrażenia.", "mage.png") {}

        public override int Attack(Character target)
        {
            int dmg = mana >= 10 ? Strength + 10 : Strength / 2;
            target.ReceiveDamage(dmg);

            if (mana >= 10)
            {
                mana -= 10;
            }

            return dmg;
        }
    }
}
