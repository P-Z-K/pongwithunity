using System;
using _Scripts.UI.Menus;
using UnityEngine;

namespace _Scripts.UI
{
    public enum MenuType
    {
        StartMenu,
        GameplayMenu,
        GameOverMenu,
    }
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private StartMenuView _startMenuView;
        [SerializeField] private GameplayMenuView _gameplayMenuView;
        [SerializeField] private GameOverMenuView _gameOverMenuView;

        private IMenu _currentMenu;

        public void ChangeMenuTo(MenuType newMenuType)
        {
            if (_currentMenu != null)
            {
                _currentMenu.IsVisible = false;
            }

            IMenu newMenu = GetMenu(newMenuType);
            newMenu.IsVisible = true;
            
            _currentMenu = newMenu;
        }

        private IMenu GetMenu(MenuType type)
        {
            switch (type)
            {
                case MenuType.StartMenu:
                    return _startMenuView;
                case MenuType.GameplayMenu:
                    return _gameplayMenuView;
                case MenuType.GameOverMenu:
                    return _gameOverMenuView;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}