using BattleGameApp.ViewModels;

namespace BattleGameApp.Views;

public partial class BattlePage : ContentPage
{
    public GameViewModel ViewModel => BindingContext;

    readonly GameViewModel BindingContext;

    public BattlePage()
	{
		InitializeComponent();

        BindingContext = new GameViewModel();
    }

    private void OnPlayTurn(object sender, System.EventArgs e)
    {    }
}