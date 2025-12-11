using BattleGameApp.Models;

namespace BattleGameApp.Views
{
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
            var selectedClass = classes[currentIndex];

            ClassNameLabel.Text = selectedClass.Name;
            ClassDescriptionLabel.Text = selectedClass.Description;
            ClassHealthLabel.Text = $"❤️ Punkty życia: {selectedClass.MaxHealth}";
            ClassStrengthLabel.Text = $"🗡️ Siła ataku: {selectedClass.Strength}";
            ClassImage.Source = ImageSource.FromFile(selectedClass.ImagePath);
        }

        private void OnPreviousClassClicked(object sender, System.EventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = classes.Count - 1;
            }

            UpdateClassDisplay();
        }

        private void OnNextClassClicked(object sender, System.EventArgs e)
        {
            currentIndex++;
            if (currentIndex >= classes.Count)
            {
                currentIndex = 0;
            }

            UpdateClassDisplay();
        }

        private async void OnStartBattleClicked(object sender, System.EventArgs e)
        {
            var selectedCharacter = classes[currentIndex];
            var battlePage = new BattlePage(selectedCharacter);

            await Navigation.PushAsync(battlePage);

            battlePage.StartBattle();
        }
    }
}