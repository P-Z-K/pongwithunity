using UnityEngine;
using Zenject;

namespace _Scripts.PongBat
{
    public class PongBatInstaller : MonoInstaller
    {
        [SerializeField] private PongBatView _pongBatView;

        public override void InstallBindings()
        {
            Container.BindInstance(_pongBatView).AsSingle();
        }
    }
}