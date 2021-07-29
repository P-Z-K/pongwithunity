using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Menus
{
    public class StartMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;

        private const MenuType _menuType = MenuType.StartMenu;

        public MenuType MenuType
        {
            get => _menuType;
        }

        public Button StartButton
        {
            get => _startButton;
        }

        public Button QuitButton
        {
            get => _quitButton;
        }
    }
}