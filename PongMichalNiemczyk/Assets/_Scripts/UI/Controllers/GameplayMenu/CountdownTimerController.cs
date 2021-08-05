using _Scripts.UI.Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    public class CountdownTimerController
    {
        private readonly GameplayMenuView _gameplayMenuView;
        private readonly CountdownTimerSettings _countdownTimerSettings;
        private readonly SignalBus _signalBus;

        private float _countdownTime;

        public CountdownTimerController(
            GameplayMenuView gameplayMenuView
            , SignalBus signalBus
            , CountdownTimerSettings countdownTimerSettings)
        {
            _gameplayMenuView = gameplayMenuView;
            _signalBus = signalBus;
            _countdownTimerSettings = countdownTimerSettings;
        }

        public void Show()
        {
            Prepare();
            _gameplayMenuView.ShowCountdownTimer();
        }

        private void Prepare()
        {
            _countdownTime = _countdownTimerSettings._delayBeforeBallStart;
            _gameplayMenuView.UpdateCountdownTimerText(Mathf.RoundToInt(_countdownTime));
        }

        public void Countdown()
        {
            if (!_gameplayMenuView.IsCountdownTimerEnabled)
            {
                return;
            }

            _countdownTime -= Time.deltaTime;
            _gameplayMenuView.UpdateCountdownTimerText(Mathf.RoundToInt(_countdownTime));

            if (_countdownTime <= 0)
            {
                Hide();
                _signalBus.Fire<CountdownAnimationFinishedSignal>();
            }
        }

        private void Hide()
        {
            _gameplayMenuView.HideCountdownTimer();
        }
    }
}