using UnityEngine;
using Zenject;

namespace _Scripts.Ball
{
    public class BallInstaller : MonoInstaller
    {
        [SerializeField] private BallView _ballView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<BallStateManager>().AsSingle();
            Container.Bind<BallMovement>().AsSingle();
            Container.BindInstance(_ballView);
        }
    }
}