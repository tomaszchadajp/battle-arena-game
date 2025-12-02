using BattleGameApp.Models;
using System.ComponentModel;

namespace BattleGameApp.ViewModels
{
    public partial class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        internal void StartBattle(Character selectedCharacter)
        {
            throw new NotImplementedException();
        }
    }
}
