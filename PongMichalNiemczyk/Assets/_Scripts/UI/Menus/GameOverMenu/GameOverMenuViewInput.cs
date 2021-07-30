using UnityEngine;
using Zenject;

namespace _Scripts.UI
{
    public class GameOverMenuViewInput : MonoBehaviour
    {
        private IGameOverMenuViewInputListener _gameOverMenuViewInputListener;

        [Inject]
        public void Construct(IGameOverMenuViewInputListener gameOverMenuViewInputListener)
        {
            _gameOverMenuViewInputListener = gameOverMenuViewInputListener;
        }

        public void OnPlayAgainButtonClick()
        {
            _gameOverMenuViewInputListener.OnPlayAgainButtonClick();
        }

        public void OnQuitButtonClick()
        {
            _gameOverMenuViewInputListener.OnQuitButtonClick();
        }
    }
}