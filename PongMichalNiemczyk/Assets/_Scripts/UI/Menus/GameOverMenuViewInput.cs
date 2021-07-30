using UnityEngine;
using Zenject;

namespace _Scripts.UI.Menus
{
    public class GameOverMenuViewInput : MonoBehaviour
    {
        private IGameOverMenuViewInput _gameOverMenuViewInput;

        [Inject]
        public void Construct(IGameOverMenuViewInput gameOverMenuViewInput)
        {
            _gameOverMenuViewInput = gameOverMenuViewInput;
        }

        public void OnPlayAgainButtonClick()
        {
            _gameOverMenuViewInput.OnPlayAgainButtonClick();
        }

        public void OnQuitButtonClick()
        {
            _gameOverMenuViewInput.OnQuitButtonClick();
        }
    }
}