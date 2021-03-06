using _Scripts.Players;
using Zenject;

namespace _Scripts.UI
{
    public class PlayerPointsController
    {
        private readonly GameplayMenuView _gameplayMenuView;
        private readonly SignalBus _signalBus;

        public PlayerPointsController(GameplayMenuView gameplayMenuView, SignalBus signalBus)
        {
            _gameplayMenuView = gameplayMenuView;
            _signalBus = signalBus;
        }

        public void SubscribeSignals() => _signalBus.Subscribe<PlayerPointsChangedSignal>(OnPlayerPointsChange);

        public void UnsubscribeSignals() => _signalBus.Unsubscribe<PlayerPointsChangedSignal>(OnPlayerPointsChange);

        private void OnPlayerPointsChange(PlayerPointsChangedSignal obj)
        {
            _gameplayMenuView.UpdatePlayerOneScoreText(obj.PlayerOnePoints);
            _gameplayMenuView.UpdatePlayerTwoScoreText(obj.PlayerTwoPoints);
        }
    }
}