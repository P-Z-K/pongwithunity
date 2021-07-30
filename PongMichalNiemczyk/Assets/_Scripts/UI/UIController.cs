using _Scripts.UI.Signals;
using Zenject;

namespace _Scripts.UI
{
    public class UIController : IStartMenuViewInputListener, IGameplayMenuView, IGameOverMenuViewInputListener
    {
        private readonly SignalBus _signalBus;

        public UIController(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void OnStartButtonClick()
        {
            _signalBus.Fire<StartButtonClickedSignal>();
        }

        public void OnPlayAgainButtonClick()
        {
            _signalBus.Fire<PlayAgainButtonClickedSignal>();
        }

        void IGameOverMenuViewInputListener.OnQuitButtonClick()
        {
            _signalBus.Fire<QuitButtonClickedSignal>();
        }

        void IStartMenuViewInputListener.OnQuitButtonClick()
        {
            _signalBus.Fire<QuitButtonClickedSignal>();
        }

        public void UpdatePlayerOneScoreText(int points)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePlayerTwoScoreText(int points)
        {
            throw new System.NotImplementedException();
        }
    }
}