using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Menus
{
    public class GameOverMenuView : MonoBehaviour, IMenu
    {
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _quitButton;

        public MenuType MenuType
        {
            get => MenuType.GameOverMenu;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

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