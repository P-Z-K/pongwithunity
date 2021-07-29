using System;
using _Scripts.UI.Menus;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public enum MenuType
    {
        StartMenu,
        GameplayMenu,
        GameOverMenu,
    }

    public class MenuManager
    {
        private readonly StartMenuView _startMenuView;
        private readonly GameplayMenuView _gameplayMenuView;
        private readonly GameOverMenuView _gameOverMenuView;

        private IMenu _currentMenu;

        public MenuManager(StartMenuView startMenuView, GameplayMenuView gameplayMenuView,
            GameOverMenuView gameOverMenuView)
        {
            _startMenuView = startMenuView;
            _gameplayMenuView = gameplayMenuView;
            _gameOverMenuView = gameOverMenuView;
        }

        public Button StartButton
        {
            get { return _currentMenu.MenuType == _startMenuView.MenuType ? _startMenuView.StartButton : null; }
        }

        public Button QuitButton
        {
            get
            {
                if (_currentMenu.MenuType == _startMenuView.MenuType)
                {
                    return _startMenuView.QuitButton;
                }

                if (_currentMenu.MenuType == _gameOverMenuView.MenuType)
                {
                    return _gameOverMenuView.QuitButton;
                }

                return null;
            }
        }

        public Button PlayAgainButton
        {
            get
            {
                return _currentMenu.MenuType == _gameOverMenuView.MenuType ? _gameOverMenuView.PlayAgainButton : null;
            }
        }


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