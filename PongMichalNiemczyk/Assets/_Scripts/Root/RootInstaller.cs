using Zenject;

namespace _Scripts.Root
{
    public class RootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Root>().AsSingle();

            Container.Bind<StartState>().AsSingle();
            Container.Bind<GameplayState>().AsSingle();
            Container.Bind<GameOverState>().AsSingle();

            SignalBusInstaller.Install(Container);
        }
    }
}