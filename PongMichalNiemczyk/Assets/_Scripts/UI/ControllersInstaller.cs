using Zenject;

namespace _Scripts.UI
{
    public class ControllersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StartMenuController>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverMenuController>().AsSingle();
            
            Container.Bind<GameplayMenuController>().AsSingle();
            Container.Bind<CountdownTimerController>().AsSingle();
            Container.Bind<PlayerPointsController>().AsSingle();
        }
    }
}