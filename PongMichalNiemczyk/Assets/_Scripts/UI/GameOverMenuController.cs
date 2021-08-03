using _Scripts.UI.Signals;
using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    public class GameOverMenuController : IGameOverMenuViewInputListener
    {
        private readonly GameOverMenuView _gameOverMenuView;
        private readonly SignalBus _signalBus;

        public GameOverMenuController(GameOverMenuView gameOverMenuView, SignalBus signalBus)
        {
            _gameOverMenuView = gameOverMenuView;
            _signalBus = signalBus;
        }

        public void Show()
        {
            _gameOverMenuView.Show();
        }

        public void Hide()
        {
            _gameOverMenuView.Hide();
        }

        public void OnPlayAgainButtonClick()
        {
            _signalBus.Fire<PlayAgainButtonClickedSignal>();
        }

        public void OnQuitButtonClick()
        {
            _signalBus.Fire<QuitButtonClickedSignal>();
        }
    }
}