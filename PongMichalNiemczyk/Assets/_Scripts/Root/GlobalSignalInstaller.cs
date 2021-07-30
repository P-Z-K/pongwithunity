using _Scripts.Ball;
using _Scripts.Root.Global_Signals;
using _Scripts.UI.Signals;
using Zenject;

namespace _Scripts.Root
{
    public class GlobalSignalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<BallHitWallSignal>();
            Container.DeclareSignal<BallHitPongBatSignal>();
            Container.DeclareSignal<BallFellIntoPlayerHoleSignal>();
            Container.DeclareSignal<PlayerPointsChangedSignal>();
            Container.DeclareSignal<PlayerWonSignal>();
            Container.DeclareSignal<StartButtonClickedSignal>();
            Container.DeclareSignal<QuitButtonClickedSignal>();
            Container.DeclareSignal<PlayAgainButtonClickedSignal>();
        }
    }
}