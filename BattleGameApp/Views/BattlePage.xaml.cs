using BattleGameApp.ViewModels;

namespace BattleGameApp.Views;

public partial class BattlePage : ContentPage
{
    GameViewModel ViewModel => BindingContext as GameViewModel;

    public BattlePage()
	{
		InitializeComponent();
	}

    private void OnPlayTurn(object sender, System.EventArgs e)
    {    }
}