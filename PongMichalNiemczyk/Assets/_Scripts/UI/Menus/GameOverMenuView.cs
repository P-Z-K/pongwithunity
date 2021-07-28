using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Menus
{
    public class GameOverMenuView : MonoBehaviour
    {
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _quitButton;

        public Button PlayAgainButton
        {
            get => _playAgainButton;
        }

        public Button QuitButton
        {
            get => _quitButton;
        }
    }
}