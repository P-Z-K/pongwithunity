using Zenject;

namespace _Scripts.UI
{
    public class ControllersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<StartMenuController>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayMenuController>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverMenuController>().AsSingle();
        }
    }
}