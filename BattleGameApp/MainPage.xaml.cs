using BattleGameApp.Views;

namespace BattleGameApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStartGame(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClassSelectPage());
        }
    }
}
