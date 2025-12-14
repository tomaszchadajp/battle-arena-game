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

        private readonly Random random = new();

        private Character player;
        private Character enemy;

        public ObservableCollection<string> Logs { get; } = new();

        public BattlePage(Character chosen)
        {
            InitializeComponent();
            BindingContext = this;

            player = chosen;
            enemy = PickEnemy();

            UpdateUI();
        }

        private Character PickEnemy()
        {
            var pick = classes[random.Next(classes.Count)];

            return pick;
        }

        private void UpdateUI()
        {
            PlayerImage.Source = player.ImagePath;
            PlayerNameLabel.Text = player.Name;
            PlayerHealthLabel.Text = $"{player.Health}/{player.MaxHealth} HP";
            PlayerHealthBar.Progress = (double)player.Health / player.MaxHealth;

            EnemyImage.Source = enemy.ImagePath;
            EnemyNameLabel.Text = enemy.Name;
            EnemyHealthLabel.Text = $"{enemy.Health}/{enemy.MaxHealth} HP";
            EnemyHealthBar.Progress = (double)enemy.Health / enemy.MaxHealth;
        }

        private async void OnAttackClicked(object sender, EventArgs e)
        {
            if (!player.IsAlive || !enemy.IsAlive)
                return;

            var dealt = player.Attack(enemy);
            Logs.Add($"🟢 {player.Name} zadaje {dealt} obrażeń");

            await AnimateHit(EnemyImage);
            UpdateUI();

            if (!enemy.IsAlive)
            {
                Logs.Add("🏆 WYGRAŁEŚ!");
                return;
            }

            await Task.Delay(700);

            var received = enemy.Attack(player);
            Logs.Add($"🔴 {enemy.Name} zadaje {received} obrażeń");

            await AnimateHit(PlayerImage);
            UpdateUI();

            if (!player.IsAlive)
            {
                Logs.Add("💀 PRZEGRAŁEŚ...");
            }
        }

        private async Task AnimateHit(Image img)
        {
            await img.TranslateTo(-10, 0, 60);
            await img.TranslateTo(10, 0, 60);
            await img.TranslateTo(0, 0, 60);
        }

        private async void OnRestartClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}
