using _Scripts.Root.Global_Signals;
using _Scripts.UI;
using Zenject;

namespace _Scripts.UI
{
    public class UI_PointsTracker
    {
        private readonly GameplayMenuView _gameplayMenuView;
        private readonly SignalBus _signalBus;

        public UI_PointsTracker(GameplayMenuView gameplayMenuView, SignalBus signalBus)
        {
            _gameplayMenuView = gameplayMenuView;
            _signalBus = signalBus;
        }

        public void SubscribeSignals()
        {
            _signalBus.Subscribe<PlayerPointsChangedSignal>(OnPlayerPointsChanged);
        }

        public void UnsubscribeSignals()
        {
            _signalBus.Unsubscribe<PlayerPointsChangedSignal>(OnPlayerPointsChanged);
        }

        private void OnPlayerPointsChanged(PlayerPointsChangedSignal obj)
        {
            _gameplayMenuView.PlayerOneScoreText.text = obj.PlayerOnePoints.ToString();
            _gameplayMenuView.PlayerTwoScoreText.text = obj.PlayerTwoPoints.ToString();
        }
    }
}