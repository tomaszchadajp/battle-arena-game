using BattleGameApp.Models;

namespace BattleGameApp.Views;

public partial class ClassSelectPage : ContentPage
{
        private List<Character> classes = new()
        {
            new Warrior(),
            new Mage(),
            new Archer()
        };
        private int currentIndex = 0;

        public ClassSelectPage()
        {
            InitializeComponent();
            UpdateClassDisplay();
        }

        private void UpdateClassDisplay()
        {
            var selected = classes[currentIndex];

            ClassNameLabel.Text = selected.Name;
            ClassDescriptionLabel.Text = selected.Description;
            ClassHealthLabel.Text = $"❤️ Punkty życia: {selected.MaxHealth}";
            ClassStrengthLabel.Text = $"🗡️ Siła ataku: {selected.Strength}";

            var imageFile = selected.Name switch
            {
                "Wojownik" => "Warrior.png",
                "Mag" => "Mage.png",
                "Łucznik" => "Archer.png",
            };

            ClassImage.Source = ImageSource.FromFile(imageFile);
        }

        private void OnPreviousClass(object sender, System.EventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0) currentIndex = classes.Count - 1;
            UpdateClassDisplay();
        }

        private void OnNextClass(object sender, System.EventArgs e)
        {
            currentIndex++;
            if (currentIndex >= classes.Count) currentIndex = 0;
            UpdateClassDisplay();
        }

        private async void OnStartBattle(object sender, System.EventArgs e)
        {
            var selectedCharacter = classes[currentIndex];

            var battlePage = new BattlePage();
        battlePage.ViewModel.StartBattle(selectedCharacter);

        await Navigation.PushAsync(battlePage);
        }
}
