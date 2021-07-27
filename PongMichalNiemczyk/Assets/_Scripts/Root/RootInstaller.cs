using _Scripts.Ball;
using Zenject;

namespace _Scripts.Root
{
    public class RootInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Root>().AsSingle();

            SignalBusInstaller.Install(Container);
            
            Container.DeclareSignal<BallHitWallSignal>();
            Container.DeclareSignal<BallHitPongBatSignal>();
            Container.DeclareSignal<BallFellIntoPlayerHoleSignal>();
        }
    }
}