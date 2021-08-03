using _Scripts.Root.Global_Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    public class GameplayMenuController
    {
        private readonly GameplayMenuView _gameplayMenuView;
        private readonly SignalBus _signalBus;

        public GameplayMenuController(GameplayMenuView gameplayMenuView, SignalBus signalBus)
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