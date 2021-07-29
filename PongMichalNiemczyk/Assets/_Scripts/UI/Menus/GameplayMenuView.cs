using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Menus
{
    public class GameplayMenuView : MonoBehaviour
    {
        [SerializeField] private Text _playerOneScoreText;
        [SerializeField] private Text _playerTwoScoreText;

        private const MenuType _menuType = MenuType.GameplayMenu;

        public MenuType MenuType
        {
            get => _menuType;
        }

        public Text PlayerOneScoreText
        {
            get => _playerOneScoreText;
        }

        public Text PlayerTwoScoreText
        {
            get => _playerTwoScoreText;
        }
    }
}