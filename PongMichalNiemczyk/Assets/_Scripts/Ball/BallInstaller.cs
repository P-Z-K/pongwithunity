using UnityEngine;
using Zenject;

namespace _Scripts.Ball
{
    public class BallInstaller : MonoInstaller
    {
        [SerializeField] private BallView _ballView;

        public override void InstallBindings()
        {
            Container.Bind<BallStateManager>().AsSingle();
            Container.Bind<BallMovement>().AsSingle();
            Container.BindInstance(_ballView).AsSingle();

            Container.DeclareSignal<BallCollisionEntered2DSignal>();
            Container.DeclareSignal<BallTriggerEntered2DSignal>();
            Container.DeclareSignal<BallHitWallSignal>();
            Container.DeclareSignal<BallHitPongBatSignal>();
        }
    }
}