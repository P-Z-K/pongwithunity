using UnityEngine;
using Zenject;

namespace _Scripts.Players
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerOneHole _playerOneHole;
        [SerializeField] private PlayerTwoHole _playerTwoHole;

        public override void InstallBindings()
        {
            Container.Bind<PointsTracker>().AsSingle();
            Container.Bind<PlayerOne>().AsSingle();
            Container.Bind<PlayerTwo>().AsSingle();

            Container.BindInstance(_playerOneHole);
            Container.BindInstance(_playerTwoHole);
        }
    }
}