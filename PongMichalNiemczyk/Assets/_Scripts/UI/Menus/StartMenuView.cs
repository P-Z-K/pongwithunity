using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.Menus
{
    public class StartMenuView : MonoBehaviour, IMenu
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _quitButton;

        public MenuType MenuType
        {
            get => MenuType.StartMenu;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
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