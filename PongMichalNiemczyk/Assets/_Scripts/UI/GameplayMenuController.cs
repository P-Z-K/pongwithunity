using _Scripts.Root.Global_Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    public class GameplayMenuController : MonoBehaviour
    {
        private GameplayMenuView _gameplayMenuView;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(GameplayMenuView gameplayMenuView, SignalBus signalBus)
        {
            _gameplayMenuView = gameplayMenuView;
            _signalBus = signalBus;
        }

        public void SubscribeSignals()
        {
            _signalBus.Subscribe<PlayerPointsChangedSignal>(OnPlayerPointsChange);
        }
        
        public void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<PlayerPointsChangedSignal>(OnPlayerPointsChange);
        }

        private void OnPlayerPointsChange(PlayerPointsChangedSignal obj)
        {
            _gameplayMenuView.UpdatePlayerOneScoreText(obj.PlayerOnePoints);
            _gameplayMenuView.UpdatePlayerTwoScoreText(obj.PlayerTwoPoints);
        }

        public void Show()
        {
            _gameplayMenuView.Show();
        }


        public void Hide()
        {
            _gameplayMenuView.Hide();
        }
    }
}