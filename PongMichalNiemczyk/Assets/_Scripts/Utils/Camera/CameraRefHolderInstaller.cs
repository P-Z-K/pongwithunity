using UnityEngine;
using Zenject;

namespace _Scripts.Utils
{
    public class CameraRefHolderInstaller : MonoInstaller
    {
        [SerializeField] private CameraRefHolder _cameraRefHolder;
        public override void InstallBindings()
        {
            Container.BindInstance(_cameraRefHolder).AsSingle();
        }
    }
}