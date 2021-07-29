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

        public bool IsVisible
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
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