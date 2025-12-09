using BattleGameApp.Models;
using System.Collections.ObjectModel;

namespace BattleGameApp.Views
{
    public partial class BattlePage : ContentPage
    {
        private readonly List<Character> classes = new()
        {
            new Warrior(),
            new Mage(),
            new Archer()
        };

        private readonly Random randomInstance = new();

        private const int attackDelayMs = 1000;

        private readonly Character player;
        private readonly Character enemy;
        private bool canContinueBattle => player.IsAlive && enemy.IsAlive;

        public ObservableCollection<string> Logs { get; } = new();

        public BattlePage(Character choosenPlayerClass)
        {
            InitializeComponent();

            BindingContext = this;
            player = choosenPlayerClass;
            enemy = PickRandomEnemy();

            UpdateUI();
        }

        private Character PickRandomEnemy()
        {
            return classes[randomInstance.Next(classes.Count)];
        }

        private void UpdateUI()
        {
            PlayerImage.Source = player.ImagePath;
            PlayerNameLabel.Text = player.Name;
            PlayerHealthLabel.Text = $"HP: {player.Health}/{player.MaxHealth}";

            EnemyImage.Source = enemy.ImagePath;
            EnemyNameLabel.Text = enemy.Name;
            EnemyHealthLabel.Text = $"HP: {enemy.Health}/{enemy.MaxHealth}";
        }

        public async void StartBattle()
        {
            Logs.Add("⚔️ WALKA ROZPOCZĘTA!");

            await FightLoop();
        }

        private async Task FightLoop()
        {
            while (canContinueBattle)
            {
                int playerDmg = player.Attack(enemy);
                Logs.Add($"🟢 {player.Name} (Ty) zadaje {playerDmg} punktów obrażeń");

                UpdateUI();
                if (!enemy.IsAlive)
                {
                    Logs.Add("🏆 Wygrana!");
                    break;
                }
                await Task.Delay(attackDelayMs);

                int enemyDmg = enemy.Attack(player);
                Logs.Add($"🔴 {enemy.Name} (Przeciwnik) zadaje {enemyDmg} punktów obrażeń");

                UpdateUI();
                if (!player.IsAlive)
                {
                    Logs.Add("💀 Przegrana...");
                    break;
                }
                await Task.Delay(attackDelayMs);
            }
        }

        public void OnRestartClicked(object sender, EventArgs e) {
            throw new NotImplementedException();
        }
    }
}
