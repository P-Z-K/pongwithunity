using UnityEngine;
using Zenject;

namespace _Scripts.UI.Menus
{
    public class MenusInstaller : MonoInstaller
    {
        [SerializeField] private StartMenuView _startMenuView;
        [SerializeField] private GameplayMenuView _gameplayMenuView;
        [SerializeField] private GameOverMenuView _gameOverMenuView;
        
        public override void InstallBindings()
        {
            Container.Bind<MenuManager>().AsSingle();
            
            Container.BindInstance(_startMenuView);
            Container.BindInstance(_gameplayMenuView);
            Container.BindInstance(_gameOverMenuView);
        }
    }
}