using UnityEngine;
using Zenject;

namespace _Scripts.Players
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerOne _playerOne;
        [SerializeField] private PlayerTwo _playerTwo;

        public override void InstallBindings()
        {
            Container.Bind<PointsTracker>().AsSingle();
            
            Container.BindInstance(_playerOne);
            Container.BindInstance(_playerTwo);
        }
    }
}