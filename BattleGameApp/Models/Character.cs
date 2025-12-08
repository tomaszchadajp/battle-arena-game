namespace BattleGameApp.Models
{
    public abstract class Character
    {
        public string Name;
        public int Health;
        public int MaxHealth;
        public int Strength;
        public string Description;
        public string ImagePath;

        public bool IsAlive => Health > 0;
        public double HealthPercent => (double)Health / MaxHealth;

        protected Character(string name, int hp, int strength, string description, string imagePath)
        {
            Name = name;
            MaxHealth = hp;
            Health = hp;
            Strength = strength;
            Description = description;
            ImagePath = imagePath;
        }

        public void ReceiveDamage(int amount)
        {
            Health -= amount;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public abstract string Attack(Character target);
    }
}
