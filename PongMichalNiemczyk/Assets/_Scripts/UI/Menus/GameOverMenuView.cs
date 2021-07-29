using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Menus
{
    public class GameOverMenuView : MonoBehaviour
    {
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Button _quitButton;
        
        private const MenuType _menuType = MenuType.GameOverMenu;

        public MenuType MenuType
        {
            get => _menuType;
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